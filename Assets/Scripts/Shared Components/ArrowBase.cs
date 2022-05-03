using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowBase : MonoBehaviour
{
    public float projectileSpeed = 100f;

    [SerializeField]
    int damage;

    Vector3 prevPosition;

    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.detectCollisions = false;
    }

    private void Update()
    {
        if (!m_Rigidbody.isKinematic) transform.LookAt(transform.position + m_Rigidbody.velocity);

        prevPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        m_Rigidbody.isKinematic = true;
        m_Rigidbody.detectCollisions = false;

        Health health = collider.GetComponent<Health>();

        if (health != null) health.Damage(damage);
    }

    public void Fire(float drawLength)
    {
        m_Rigidbody.detectCollisions = true;
        m_Rigidbody.isKinematic = false;
        m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        transform.parent = null;
        projectileSpeed *= drawLength;
        Vector3 inheritVelocity = ((transform.position - prevPosition) / Time.deltaTime);
        m_Rigidbody.AddForce(transform.forward * (projectileSpeed > inheritVelocity.magnitude ? projectileSpeed : inheritVelocity.magnitude), ForceMode.VelocityChange);
        Debug.Log(inheritVelocity);
    }
}
