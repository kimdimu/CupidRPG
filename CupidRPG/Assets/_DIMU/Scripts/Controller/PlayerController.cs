using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Entity
{
    Movement movement;
    Health health;
    Camera cam;
    Fighter fighter;
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
    private void Update()
    {
        if (health.IsDead() || !GameManager.Instance.isGameStart)   return;
        PlayerAttack();
        if (fighter.IsAttacking())
            return;

    }
    void FixedUpdate()
    {
        if (health.IsDead() || !GameManager.Instance.isGameStart)
            return;
        //DecreaseHP();
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
            AimImageManager.Instance.AimUIOnOff(true);
            print("Down");
        }


        if (Input.GetMouseButton(1))
        {
            chargetime += Time.deltaTime;
            if(chargetime<chargeTimes[0])
            {
                AimImageManager.Instance.ChangeChargeColor(0);
                fighter.AdditionalPowerSetting(0);
            }
            else if(chargetime < chargeTimes[1])
            {
                AimImageManager.Instance.ChangeChargeColor(1);
                fighter.AdditionalPowerSetting(20);

            }
            else if(chargetime < chargeTimes[2])
            {
                AimImageManager.Instance.ChangeChargeColor(2);
                fighter.AdditionalPowerSetting(40);
            }

            if (!fighter.IsAttacking() && Input.GetMouseButtonDown(0))
            {
                fighter.ShootTriggerOn();
                chargetime = 0;
            }
            print("Ing");

        }
        if (Input.GetMouseButtonUp(1))
        {
            AimImageManager.Instance.AimUIOnOff(false);
            CameraManager.Instance.CameraSwitch(CameraType.Default);
            AimImageManager.Instance.ChangeChargeColor(0);
            chargetime = 0;
            fighter.AdditionalPowerSetting(0);
            print("Up");

        }
    }

}
