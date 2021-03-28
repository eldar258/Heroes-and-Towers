using UnityEngine;
using UnityEditor;

public class StateShoot : IState
{
    private Animator animator;
    private Transform startShot;
    private float maxDistace = 100;
    private float timeLastShot = 0;
    private bool isRedyToShot = false;
    private RaycastHit hitInfo;
    private Transform playerTransform;

    public StateShoot()
    {
        Player player = HeroManager.instance.Player;
        this.animator = player.GetComponent<Animator>();
        this.startShot = player.CenterHand;
        this.playerTransform = player.GetComponent<Transform>();
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
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("isShot");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            isRedyToShot = Physics.Raycast(ray, out hitInfo, maxDistace);
        }
    }

    public void PhysicAction()
    {
        if (isRedyToShot)
        {
            rotateHeroToShot();
            if (isPossibleShoot())
            {
                createShot(hitInfo.point);
                timeLastShot = Time.fixedTime;
                isRedyToShot = false;
            }
        }
    }

    private void createShot(Vector3 point)
    {
        BulletSpawner.instance.createBullet(startShot.position, point);
    }

    private void rotateHeroToShot()
    {
        playerTransform.rotation = Quaternion.LookRotation(hitInfo.point - playerTransform.position);
        playerTransform.Rotate(0, 90, 0);
    }

    private bool isPossibleShoot()
    {
        return Time.fixedTime - timeLastShot > HeroManager.instance.CurrentGunSetting.SecondForShot;
    }
}