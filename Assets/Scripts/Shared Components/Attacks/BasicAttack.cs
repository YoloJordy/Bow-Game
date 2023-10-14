using UnityEngine;

public abstract class BasicAttack : MonoBehaviour
{
    [SerializeField]
    protected int damage = 5;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

        var health = collider.GetComponentInParent<Health>();
        if (health != null) health.Damage(damage, collider.tag);
    }
}
