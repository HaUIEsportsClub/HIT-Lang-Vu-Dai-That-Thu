using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGate : MonoBehaviour
{
    [SerializeField] private Transform posTeleGate;
    [SerializeField] private GameObject player;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.main.gameObject.transform.position = new Vector3(Camera.main.gameObject.transform.position.x  + 53f, Camera.main.gameObject.transform.position.y, Camera.main.gameObject.transform.position.z);
            Vector3 p = posTeleGate.position;
            p.x += 3f;
            player.transform.position = p;
        }
    }
     
}
