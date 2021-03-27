using UnityEngine;
using UnityEditor;

public class StateShoot : IState
{
    Animator animator;
    public StateShoot(Animator animator)
    {
        this.animator = animator;
    }
    public void Enter()
    {
        animator.SetBool("isShootingState", true);
    }

    public void Exit()
    {
        animator.SetBool("isShootingState", false);
    }

    public void GraphicAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("isShot");
        }
    }

    public void PhysicAction()
    {
        //TODO
    }
}