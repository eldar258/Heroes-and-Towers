using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask layerMask;
    public float maxRemainingDistanceForIdle = 1;


    private Animator animator;
    private float maxDistandceOfRay = 100;
    private NavMeshAgent myAgent;
    private RaycastHit hitInfo = new RaycastHit();

    private bool isRun;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRun = false;
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, maxDistandceOfRay, layerMask))
                myAgent.SetDestination(hitInfo.point);
        } 
    }

    private void FixedUpdate()
    {
        isRun = myAgent.remainingDistance > maxRemainingDistanceForIdle;
        animator.SetBool("isRun", isRun);
    }
}
