using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    BowController bowController;
    LineRenderer lineRenderer;

    [SerializeField] int numPoints = 50;
    [SerializeField] float timeBetweenPoints = 0.1f;
    [SerializeField] LayerMask layerMask;

    bool projecting = false;
    
    void Start()
    {
        bowController = GetComponent<BowController>();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = numPoints;

        InputHandler.current.onChargeStart += StartProjection;
        InputHandler.current.onChargeRelease += StopProjection;
    }

    void LateUpdate()
    {
        if (projecting)
        {
            List<Vector3> points = new List<Vector3>();
            Vector3 startPosition = bowController.spawnPoint.position;
            Vector3 startVelocity = bowController.GetProjectileForce;

            for (var t = 0f; t < numPoints; t += timeBetweenPoints)
            {
                Vector3 newPoint = startPosition + t * startVelocity;
                newPoint.y = startPosition.y + startVelocity.y * t + Physics.gravity.y / 2f * t * t;
                points.Add(newPoint);

                var prevPoint = points.Count > 1 ? points[points.Count - 2] : startPosition;
                var rayDirection = newPoint - prevPoint;

                RaycastHit hit;
                if (Physics.Raycast(prevPoint, rayDirection, out hit, rayDirection.magnitude, layerMask))
                {
                    lineRenderer.positionCount = points.Count;
                    points[points.Count - 1] = hit.point;
                    break;
                }
            }
            lineRenderer.SetPositions(points.ToArray());
        }
    }

    public void StartProjection()
    {
        if (bowController.loadedArrow != null)
        {
            projecting = true;
            lineRenderer.enabled = true;
        }
    }

    public void StopProjection()
    {
        projecting = false;
        lineRenderer.enabled = false;
    }
}
