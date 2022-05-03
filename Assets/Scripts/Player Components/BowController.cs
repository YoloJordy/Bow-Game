using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public ArrowBase arrowPrefab;
    ArrowBase loadedArrow;
    [SerializeField] Transform spawnTransform;

    [SerializeField] float chargeTime = 2.5f;
    float chargeMax = 1f;
    bool charging = false;
    float drawLenght = 0f;

    [SerializeField] float shootCooldown = 1f;

    private void Start()
    {
        Invoke("SpawnArrow", shootCooldown);
        InputHandler.current.onChargeStart += OnChargeStart;
        InputHandler.current.onChargeRelease += OnChargeRelease;
    }

    private void Update()
    {
        if (charging && drawLenght < chargeMax)
        {
            drawLenght += chargeMax / chargeTime * Time.deltaTime;
        }
    }

    public void OnChargeRelease()
    {
        if (charging)
        {
            Fire(drawLenght < chargeMax ? drawLenght : chargeMax);
            charging = false;
            drawLenght = 0f;
            Invoke("SpawnArrow", shootCooldown);
        }
    }

    public void OnChargeStart()
    {
        if (loadedArrow != null) charging = true;
    }

    public void Fire(float drawLength)
    {
        if (loadedArrow != null)
        {
            loadedArrow.Fire(drawLength);
            loadedArrow = null;
        }
    }

    void SpawnArrow()
    {
        loadedArrow = Instantiate(arrowPrefab, spawnTransform.position, transform.rotation, transform);
    }
}
