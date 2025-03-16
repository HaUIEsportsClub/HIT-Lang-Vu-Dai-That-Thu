using System.Collections;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    private PlayerController player;
    public float spawnRate = 2f; 
    [SerializeField] private CrossHair crossHairPrefab;

    void Start()
    {
        player =   FindAnyObjectByType<PlayerController>();
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            SpawnBulletAmmo();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnBulletAmmo()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position; 
            
            CrossHair cross =  Instantiate(crossHairPrefab, targetPosition, Quaternion.identity);
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            
            if (bulletScript != null)
            {
                bulletScript.SetTarget(targetPosition);
            }
        }
    }
}