using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int healthOrg;
    [SerializeField]
    int health;
    bool isdead = false;
    private void Awake()
    {
        health = healthOrg;
    }

    public void GetDamage(int dmg)
    {
        health -= dmg;
        if(health<=0)
        {
            Die();
        }
    }
    public bool IsDead()
    {
        return isdead;
    }
    private void Die()
    {
        isdead = true;
            GetComponent<Animator>().SetTrigger("Die");
        Debug.Log("쥭음");
    }

    public bool IsFullHp()
    {
        return health== healthOrg;
    }
    public float FillAmount()
    {
        return (float)health / healthOrg;
    }
}
