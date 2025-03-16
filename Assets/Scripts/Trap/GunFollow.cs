using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
       player =   FindAnyObjectByType<PlayerController>();
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position; 
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
            transform.rotation = Quaternion.Euler(0, 0, angle + 180f); 
        }
    }
}
