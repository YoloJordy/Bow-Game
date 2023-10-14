using UnityEngine;

public class Projectile : BasicAttack
{

    [System.NonSerialized] public int index;

    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!m_Rigidbody.isKinematic) transform.LookAt(transform.position + m_Rigidbody.velocity);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        m_Rigidbody.isKinematic = true;
        transform.parent = collision.collider.transform;

        Debug.Log("Hit: " + collision.collider);
    }

    public void Fire(Vector3 projectileForce)
    {
        m_Rigidbody.isKinematic = false;
        m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        transform.parent = null;
        m_Rigidbody.AddForce(projectileForce, ForceMode.VelocityChange);
    }
}
