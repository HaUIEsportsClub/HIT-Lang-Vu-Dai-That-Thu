using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private FallingTrap trap;
    private Animator ani;
    
    void Start()
    {
        ani = GetComponent<Animator>();
        trap.gameObject.SetActive(false);
        trap.isFalling = false;
        ani.enabled = false;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trap.gameObject.SetActive(true);
            trap.isFalling = true;
            ani.enabled = true;
        }
    }
}
