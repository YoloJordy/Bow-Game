using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 10;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public int GetHealth
    {
        get { return health; }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        Debug.Log(gameObject.name + " health = " + health);
    }

    public bool IsDead
    {
        get { return health <= 0; }
    }

}
