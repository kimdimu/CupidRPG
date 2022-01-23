using UnityEngine;

public class PlayerController : MonoBehaviour, Entity
{
    Movement movement;
    Health health;
    Camera cam;
    Fighter fighter;
    bool isMoving = false;
    [SerializeField] float hpDecSpeed;

    
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
        DecreaseHP();

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
        if (!fighter.IsAttacking() && Input.GetMouseButtonDown(0))
            fighter.ShootTriggerOn();
    }
}
