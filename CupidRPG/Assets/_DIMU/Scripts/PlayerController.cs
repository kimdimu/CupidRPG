using UnityEngine;

public class PlayerController : MonoBehaviour, Entity
{
    Movement movement;
    Health health;
    Camera cam;
    Fighter fighter;
    bool isMoving = false;
    [SerializeField] float hpDecSpeed;
    [SerializeField] float[] chargeTimes;
    float chargetime = 0;

    private void Awake()
    {
        fighter = GetComponent<Fighter>();
        movement = GetComponent<Movement>();
        health = GetComponent<Health>();
        cam = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        if (health.IsDead() || !GameManager.Instance.isGameStart)
        {
            return;
        }
        //DecreaseHP();

        PlayerAttack();
        if (fighter.IsAttacking())
            return;
        PlayerMove();
        PlayerJump();
        movement.UpdateAnimation();
    }

    private void DecreaseHP()
    {
        health.GetDamage(hpDecSpeed * Time.deltaTime);
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            movement.Jump();
    }
    private void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            movement.Move(h, v, Input.GetKey(KeyCode.LeftShift));
            movement.RotateTo(cam.transform.localRotation.eulerAngles.y);
        }
        else movement.SetSpeed(0);
    }
    private void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CameraManager.Instance.CameraSwitch(CameraType.Aim);
        }


        else if (Input.GetMouseButton(1))
        {
            CameraManager.Instance.CameraSwitch(CameraType.Aim);
            chargetime += Time.deltaTime;
            if(chargetime<chargeTimes[0])
            {
                AimImageManager.Instance.ChangeChargeColor(0);
            }
            else if(chargetime < chargeTimes[1])
            {
                AimImageManager.Instance.ChangeChargeColor(1);
                fighter.PowerUp(20);

            }
            else if(chargetime < chargeTimes[2])
            {
                AimImageManager.Instance.ChangeChargeColor(2);
                fighter.PowerUp(40);
            }

            if (!fighter.IsAttacking() && Input.GetMouseButtonDown(0))
            {
                fighter.ShootTriggerOn();
                chargetime = 0;
            }
        }
        else
        //if (Input.GetMouseButtonUp(1))
        {
            CameraManager.Instance.CameraSwitch(CameraType.Default);
            AimImageManager.Instance.ChangeChargeColor(0);
            chargetime = 0;
            fighter.ResetPower();
        }
    }
}
