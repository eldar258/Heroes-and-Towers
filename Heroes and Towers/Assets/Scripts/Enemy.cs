using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform heroPosition;
    private NavMeshAgent agent;

    
    // Start is called before the first frame update
    void Start()
    {
        heroPosition = HeroManager.instance.Player.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(heroPosition.position);
    }
}
