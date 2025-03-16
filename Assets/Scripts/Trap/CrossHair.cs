using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CrossHair : MonoBehaviour
{
    public float currrentTime = 0f;
    void Update()
    {
        currrentTime += Time.deltaTime;
        if (currrentTime >= 6f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rocket") )
        {
            Destroy(gameObject);
        }
    }
}
