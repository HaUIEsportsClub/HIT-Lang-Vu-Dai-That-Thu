using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; 
    private Vector3 targetPosition; 
    private Vector3 moveDirection;
    [SerializeField] private GameObject explosionPre;
    
    
    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        moveDirection = (targetPosition - transform.position).normalized; 
    }

    void Update()
    {
        
        transform.position += moveDirection * speed * Time.deltaTime;

       
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPre, transform.position, Quaternion.identity);
            explosion.SetActive(true);
            Destroy(explosion,0.35f);
            CameraShake.Shake(0.5f, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPre, transform.position, Quaternion.identity);
            explosion.SetActive(true);
            Destroy(explosion,0.35f);
            CameraShake.Shake(0.5f, 0.5f);
        }
    }
}