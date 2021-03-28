using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Health {
        get { return health; }
        set {if (!isEnemyDeath) health = value;}
    }
    [SerializeField]
    private float health = 100;
    private Transform heroPosition;
    private NavMeshAgent agent;
    private Animator animator;
    private bool isEnemyDeath = false;
    
    // Start is called before the first frame update
    void Start()
    {
        heroPosition = HeroManager.instance.Player.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnemyDeath) return;
        agent.SetDestination(heroPosition.position);
        if (Health <= 0) EnemyDeath();
    }

    public void EnemyDeath()
    {
        if (!isEnemyDeath)
        {
            isEnemyDeath = true;
            agent.enabled = false;
            animator.enabled = false;
        }
    }
}
