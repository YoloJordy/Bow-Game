using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 10;
    int health;

    float timeLastDamage = 0;

    [SerializeField] float weakPointModifier = 2f;
    [SerializeField] float resistPointModifier = 0.5f;

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

    public void Damage(int amount, string tag)
    {
        if (Time.time <= timeLastDamage) return;

        var modifier = 1f;
        if (tag == "WeakPoint") modifier = weakPointModifier;
        else if (tag == "ResistPoint") modifier = resistPointModifier;

        health -= (int)(amount * modifier);
        if (health < 0) health = 0;
        Debug.Log(gameObject.name + " health = " + health);

        timeLastDamage = Time.time;
    }

    public bool IsDead
    {
        get { return health <= 0; }
    }

}
