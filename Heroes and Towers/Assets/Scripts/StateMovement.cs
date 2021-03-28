using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Логика состояния передвежения у игрока
/// </summary>
public class StateMovement : IState
{
    /// <summary>
    /// Маска, по которой может ходить игрок
    /// </summary>
    public LayerMask layerMask;

    private float maxRemainingDistanceForIdle = 0.3f;
    private Animator animator;
    private float maxDistandceOfRay = 100;
    private NavMeshAgent myAgent;
    private RaycastHit hitInfo;

    public StateMovement()
    {
        Player player = HeroManager.instance.Player;
        this.animator = player.GetComponent<Animator>();
        myAgent = player.GetComponent<NavMeshAgent>();
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