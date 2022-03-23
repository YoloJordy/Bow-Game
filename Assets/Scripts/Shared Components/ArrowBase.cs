using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowBase : MonoBehaviour
{
    public float projectileSpeed = 100f;

    [SerializeField]
    int damage = 1;

    [System.NonSerialized] 
    public float drawLength;

    bool stuck = false;

    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stuck)
        {
            transform.LookAt(transform.position + m_Rigidbody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        m_Rigidbody.detectCollisions = false;
        stuck = true;

        if (collision.collider.tag.Contains("Enemy")) collision.collider.GetComponent<Health>().Damage(damage);
    }

    public void Fire()
    {
        projectileSpeed *= drawLength;
        m_Rigidbody.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }
}
