using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    private bool isAttaking;
    [SerializeField]
    private Transform hand; //공격할 손
    [SerializeField]
    private Projectile[] projectiles; //총알
    private int projectileCount=0; //총알
    [SerializeField]
    Camera cam; //에이밍을 위한 카메라
    [SerializeField]
    Image iconImage; //에이밍을 위한 카메라
    float addAttackPower;


    int layerMask = ~(1 << 8);

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        InputManager.Instance.OnPressLeftShiftDown = ChangeArrow;
        UpdateIconSprite();
    }
    public void ChangeArrow()
    {
        if (++projectileCount >= projectiles.Length) projectileCount = 0;
        UpdateIconSprite();
    }

    private void UpdateIconSprite()
    {
        iconImage.sprite = projectiles[projectileCount].icon;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10000, layerMask))
        {
            Projectile projectile = Instantiate(projectiles[projectileCount], hand.position, Quaternion.identity);
            projectile.SetAddPower(addAttackPower);
            projectile.transform.LookAt(hit.point);
            Debug.Log("non Player " + hit.point + " " + hit.collider.name);
        }
        else
        {
            Projectile projectile = Instantiate(projectiles[projectileCount], hand.position, Quaternion.identity);
            projectile.SetAddPower(addAttackPower);
            projectile.transform.rotation = cam.transform.rotation;
            Debug.Log("Player or non");
        }
    }
    public void Hit()
    {

    }
    public void AdditionalPowerSetting(float power)
    {
        addAttackPower = power;
    }
    public void ShootTriggerOn()
    {
        GetComponent<Animator>().SetTrigger("Attack1");
        isAttaking = true;
    }

    public void AttackEnd()
    {
        GetComponent<Animator>().ResetTrigger("Attack1");
        isAttaking = false;
    }
    public bool IsAttacking()
    {
        return isAttaking;
    }

}
