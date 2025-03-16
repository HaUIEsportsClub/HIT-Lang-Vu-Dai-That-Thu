using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkVaCham : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            playerData.isTele = false;
        }
    }
}
