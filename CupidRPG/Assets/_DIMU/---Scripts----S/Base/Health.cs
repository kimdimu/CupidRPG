using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int healthOrg;
    [SerializeField]
    float health;
    bool isdead = false;
    [SerializeField]
    GameObject[] dropItems;

    private void Awake()
    {
        health = healthOrg;
    }

    public void GetDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
        else if(health >= healthOrg)
        {
            health = healthOrg;
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
        if (GetComponent<AIController>())
        {
            ++AIController.enemyDeathCount;
            if(AIController.enemyCount == AIController.enemyDeathCount)
            {
                //End
                GameManager.Instance.GameEnd();
            }
        }
        DropItems();
    }
    public void DropItems()
    {
        if (dropItems.Length <= 0) return;
        foreach (var item in dropItems)
        {
            GameObject ditem = Instantiate(item,transform.position, Quaternion.identity)as GameObject;
            Debug.Log("Drop");
        }
    }
    public bool IsFullHp()
    {
        return health == healthOrg;
    }
    public float FillAmount()
    {
        return health / healthOrg;
    }
}
