using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public ArrowBase arrow;

    float arrowOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(float drawLength, Vector3 forward)
    {
        ArrowBase newArrow = Instantiate(arrow, transform.position + (arrowOffset * forward),
                    Quaternion.LookRotation(forward));
        newArrow.drawLength = drawLength;
    }
}
