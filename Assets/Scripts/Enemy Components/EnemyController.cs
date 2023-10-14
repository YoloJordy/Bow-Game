using UnityEngine;

public class EnemyController : Entity
{
    Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        //if (health.GetHealth < 1) Destroy(gameObject);
    }

    public virtual void Attack()
    {

    }
}
