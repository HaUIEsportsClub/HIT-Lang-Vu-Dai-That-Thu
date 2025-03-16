using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallAn : MonoBehaviour
{
    private TilemapRenderer spriteRenderer;
    private bool isVa = false;

    void Start()
    {
        spriteRenderer = GetComponent<TilemapRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isVa = true;
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isVa = false;
            spriteRenderer.enabled = true;
        }
    }
    
    
}
