using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    private bool isAttaking;
    [SerializeField]
    private Transform hand; //공격할 손
    [SerializeField]
    private Projectile[] projectiles; //총알
    private int projectileCount = 0; //총알
    [SerializeField]
    Camera cam; //에이밍을 위한 카메라
    [SerializeField]
    Image iconImage; //에이밍을 위한 카메라
    float addAttackPower;
    float attackCool = 1;

    [SerializeField]
    Weapon defaultWeapon;
    List<Weapon> weaponList = new List<Weapon>();
    int curWeaponIdx = 0;

    int layerMask = ~(1 << 8);

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        InputManager.Instance.OnPressLeftShiftDown = ChangeArrow;
        InputManager.Instance.numberKeyDown = ChangeWeapon;
        UpdateIconSprite();

        AddWeapon(defaultWeapon);
    }

    public void AddWeapon(Weapon newWeapon)
    {
        if (weaponList.Contains(newWeapon)) return;
        weaponList.Add(newWeapon);
        ChangeWeapon(weaponList.Count - 1, 0);
    }
    public float AttackSpeed()
    {
        return weaponList[curWeaponIdx].AdditionalAttackSpeed();
    }
    public void ChangeWeapon(int idx, int type)
    {
        if (idx > weaponList.Count || idx == curWeaponIdx) return;
        if (type == 0)
            curWeaponIdx = idx;
        else if (type == 1)
        {
            curWeaponIdx += idx;
            if (curWeaponIdx < 0)
            {
                curWeaponIdx = weaponList.Count - 1;
            }
        }
        else if (type == 2)
        {
            curWeaponIdx += idx;
            if (curWeaponIdx > weaponList.Count - 1)
            {
                curWeaponIdx = 0;
            }
        }
        print("현재 무기 " + curWeaponIdx + " ," + weaponList.Count);
        ChangeFab();
    }

    private void ChangeFab()
    {
        Destroy(hand.GetChild(0).gameObject);
        weaponList[curWeaponIdx].InstantiateHandWeapon(hand);
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
        addAttackPower = power + weaponList[curWeaponIdx].AdditionalWeaponDamage();
    }
    public void ShootInteger(int num)
    {
        GetComponent<Animator>().SetInteger("FIreAni", num);
    }

    public void ShootTrigger()
    {
        GetComponent<Animator>().ResetTrigger("Attack1");
        GetComponent<Animator>().SetTrigger("Attack1");
    }

    public void AttackStart()
    {
        isAttaking = true;
        StartCoroutine(CoolDown());
    }
    System.Collections.IEnumerator CoolDown()
    {
        float cool = 0;
        while (cool < attackCool)
        {
            cool += Time.deltaTime;
            yield return null;
        }
        isAttaking = false;
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
