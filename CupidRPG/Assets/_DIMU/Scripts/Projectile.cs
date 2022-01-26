using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetimeOrg;
    private float lifetime;
    public float speed;
    public float damage;
    public float addDamage;
    private void Update()
    {
        transform.Translate(0, 0, speed*Time.deltaTime);
        lifetime += Time.deltaTime;
        if(lifetime > lifetimeOrg)
            Destroy(gameObject);
    }

    public void SetAddPower(float power)
    {
        addDamage = power;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health && !other.CompareTag("Player"))
        {
            health.GetDamage(damage + addDamage + Random.Range(-5,10));
            Destroy(gameObject);
        }
    }
}
