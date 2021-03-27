using UnityEngine;
using UnityEngine.AI;

public class StateMovement : IState
{
    public LayerMask layerMask;

    private float maxRemainingDistanceForIdle = 0.3f;
    private Animator animator;
    private float maxDistandceOfRay = 100;
    private NavMeshAgent myAgent;
    private RaycastHit hitInfo = new RaycastHit();

    // Start is called before the first frame update
    public StateMovement(Animator animator, NavMeshAgent navMeshAgent)
    {
        this.animator = animator;
        myAgent = navMeshAgent;
        layerMask.value = LayerMask.GetMask("Ground");
    }

    public void Enter()
    {
        idle();
    }

    public void Exit()
    {
        idle();
    }

    // Update is called once per frame
    public void GraphicAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, maxDistandceOfRay, layerMask))
                myAgent.SetDestination(hitInfo.point);
        }
    }

    public void PhysicAction()
    {
        animator.SetBool("isRun", myAgent.remainingDistance > maxRemainingDistanceForIdle);
    }

    private void idle()
    {
        animator.SetBool("isRun", false);
    }
}