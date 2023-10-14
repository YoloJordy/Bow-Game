using UnityEngine;

public class BowController : MonoBehaviour
{
    public Projectile arrowPrefab;
    [System.NonSerialized] public Projectile loadedArrow;
    public Transform spawnPoint;

    Projectile[] arrows = new Projectile[10];
    int currentArrow = 0;

    [SerializeField] float drawTime = 2.5f;
    float drawMax = 1f;
    bool charging = false;
    [SerializeField] float maxProjectileSpeed = 25f;
    [SerializeField] float minProjectileSpeed = 5f;
    float drawLenght = 0f;

    [SerializeField] float shootCooldown = 1f;

    private void Start()
    {
        for (int i = 0; i < arrows.Length; i++) {
            arrows[i] = Instantiate(arrowPrefab, new Vector3(0, -1000, 0), transform.rotation);
            arrows[i].enabled = false;
            arrows[i].index = i;
        }

        drawLenght = minProjectileSpeed / maxProjectileSpeed;
        Invoke("SpawnArrow", shootCooldown);
        InputHandler.current.onChargeStart += OnChargeStart;
        InputHandler.current.onChargeRelease += OnChargeRelease;
    }

    private void Update()
    {
        if (charging && drawLenght < drawMax)
        {
            drawLenght += drawMax / drawTime * Time.deltaTime;
        }
    }

    public Vector3 GetProjectileForce
    {
        get 
        {
            return loadedArrow != null ? loadedArrow.transform.forward * (maxProjectileSpeed * (drawLenght < drawMax ? drawLenght : drawMax)) : Vector3.zero; 
        }
    }

    public void OnChargeRelease()
    {
        if (charging)
        {
            Fire(GetProjectileForce);
            charging = false;
            drawLenght = minProjectileSpeed / maxProjectileSpeed;
            Invoke("SpawnArrow", shootCooldown);
        }
    }

    public void OnChargeStart()
    {
        if (loadedArrow != null) charging = true;
    }

    public void Fire(Vector3 projectileForce)
    {
        if (loadedArrow != null)
        {
            loadedArrow.Fire(projectileForce);
            loadedArrow = null;
        }
    }

    private void SpawnArrow()
    {
        loadedArrow = arrows[currentArrow];

        loadedArrow.enabled = true;
        loadedArrow.transform.parent = transform;
        loadedArrow.transform.position = spawnPoint.position;
        loadedArrow.transform.rotation = transform.rotation;

        currentArrow++;
        if (currentArrow >= arrows.Length) currentArrow = 0;
    }
}
