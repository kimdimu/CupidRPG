using System.Collections;
using UnityEngine;

public class AIController : MonoBehaviour, Entity
{
    public static int enemyCount;
    public static int enemyDeathCount=31;
    [SerializeField]
    GameObject player;
    Movement movement;
    Health health;
    [SerializeField]
    float attackCool;
    [SerializeField] float weaponRange = 2f;
    float attackBetweenTime;
    public float chaseDistance = 20;
    void Awake()
    {
        ++enemyCount;
        movement = GetComponent<Movement>();
        health = GetComponent<Health>();
    }
    void Update()
    {
        attackBetweenTime += Time.deltaTime;
        if (health.IsDead() || !GameManager.Instance.isGameStart)
        {
            return;
        }
        movement.UpdateAnimation();


        if (InAttackRangeOfPlayer(weaponRange))
        {
            AttackB();
            return;
        }
        else if (InAttackRangeOfPlayer(chaseDistance) || !health.IsFullHp())
        {
            movement.MoveTo(player.transform);
        }
        else
        {
            movement.SetSpeed(0);
        }
    }
    private void AttackB()
    {
        if (attackBetweenTime > attackCool)
        {
            attackBetweenTime = 0;
            Debug.Log("isAttack");
            GetComponent<Animator>().SetTrigger("Attack1");
        }
    }
    private bool InAttackRangeOfPlayer(float range)
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        return distanceToPlayer < range;
    }
    private void Hit()
    {
        //player.GetComponent<Health>().GetDamage(10);
        StartCoroutine(AttackCycle());
    }

    public void AttackEnd()
    {
        GetComponent<Animator>().ResetTrigger("Attack1");
    }
    IEnumerator AttackCycle()
    {
        player.GetComponent<Health>().GetDamage(10);
        Debug.Log("AttackCycle");
        yield return new WaitForSeconds(attackCool);
    }

}
