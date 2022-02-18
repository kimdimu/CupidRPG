using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/new Weapon", order = 0)]
public class Weapon : ItemSo
{
    [SerializeField]
    string weaponName;
    [SerializeField]
    string weaponExplain;
    [SerializeField]
    GameObject realWeaponFab;//손에 쥘 무기 모델링
    [SerializeField]
    float weaponDamage; //무기 공격력
    [SerializeField]
    float weaponAttackSpeed; //무기 공격속도

    public void Awake()
    {
        PlayEffects();
    }
    public void InstantiateHandWeapon(Transform handpos)
    {
        Instantiate(realWeaponFab, handpos);
    }
    public float AdditionalAttackSpeed() => weaponAttackSpeed;
    public float AdditionalWeaponDamage() => weaponDamage;
}
