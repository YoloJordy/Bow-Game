using UnityEngine;

public class GroundSlam : BasicAttack
{

    Collider[] colliders;

    void Start()
    {
        Debug.Log(damage);
        colliders = GetComponentsInChildren<Collider>();
    }
}
