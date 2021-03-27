using UnityEngine;
using UnityEditor;

public class StateShoot : IState
{
    public BulletSpawner BulletSpawner;

    private Animator animator;
    private Transform startShot;
    private float maxDistace = 100;
    public StateShoot(Animator animator, Transform startShot)
    {
        this.animator = animator;
        this.startShot = startShot;
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
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, maxDistace))
            {
                createShot(hitInfo.point);
            }
        }
    }

    public void PhysicAction()
    {
        //TODO
    }

    private void createShot(Vector3 point)
    {
        BulletSpawner.instance.createBullet(startShot.position, point);
    }
}