using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightningTrap : MonoBehaviour
{
   [SerializeField] private float timeActive = 2f;
   [SerializeField] private float timeNotActive = 3f;
   [SerializeField] private Animator ani;
   [SerializeField] private float currentTime = 0f;
   private BoxCollider2D box;

   private bool isActive = true;

   void Start()
   {
      box = GetComponent<BoxCollider2D>();
      isActive = true;
   }
   void FixedUpdate()
   {
      
         currentTime += Time.deltaTime;
      

      if (currentTime >= timeActive && isActive )
      {
         ani.SetBool("IsActive",false);
         box.isTrigger = true;
         isActive = false;
         currentTime = 0f;
      }

      if (currentTime >= timeNotActive && !isActive)
      {
         ani.SetBool("IsActive",true);
         box.isTrigger = false;
         isActive = true;
         currentTime = 0f;
      }
   }
}
