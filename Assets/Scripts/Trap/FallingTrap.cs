using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    private BoxCollider2D bc;
    public float gravity = 9.8f; 
    private float velocity = 0f; 
    public bool isFalling = false;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isFalling)
        {
            velocity += gravity * Time.deltaTime; 
            transform.position -= new Vector3(0, velocity * Time.deltaTime, 0); 
        }
        if(gameObject.transform.position.y < -15f) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bc.size = new Vector2(3.33f, 0.68f);
            bc.offset = new Vector2(0, -1.16f);
            bc.isTrigger = false;
            isFalling = true;

        }
    }
}

