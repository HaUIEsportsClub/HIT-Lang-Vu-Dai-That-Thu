using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallTrap1 : MonoBehaviour
{
    private TilemapRenderer sr;
    private void Start()
    {
        sr = GetComponent<TilemapRenderer>();
        sr.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.enabled = true;
        }
    }
}
