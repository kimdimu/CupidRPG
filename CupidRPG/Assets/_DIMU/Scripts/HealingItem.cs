using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] int healAmount;
    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Debug.Log("추돌");
        if(health && collision.collider.CompareTag("Player"))
        {
            health.GetDamage(-healAmount);
            Destroy(gameObject);
        }
    }
}
