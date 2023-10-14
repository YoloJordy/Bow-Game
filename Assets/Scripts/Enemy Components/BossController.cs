using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField] GroundSlam groundSlam;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        
    }

    private void Update()
    {
    }

    public override void Attack()
    {
        base.Attack();

        Instantiate(groundSlam, transform.position + offset, transform.rotation);
    }
}
