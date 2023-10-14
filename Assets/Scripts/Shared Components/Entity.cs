using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private void OnDestroy()
    {
        Projectile[] arrows = GetComponentsInChildren<Projectile>();
        foreach (var arrow in arrows)
        {
            arrow.transform.parent = null;
            arrow.transform.position = new Vector3(0, -1000, 0);
        }
    }
}
