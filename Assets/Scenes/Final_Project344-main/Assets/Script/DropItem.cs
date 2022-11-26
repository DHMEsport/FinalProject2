using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
   private Inventory _inventory; 
   private int item;
 
   private void Start()
   {
      _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
   }

   private void Update()
   {
      if (transform.childCount<=0)
      {
         _inventory.isFull[item] = false;
      }
   }

   public void Drop()
   {
      foreach (Transform child in transform)
      {
         child.GetComponent<SpawnDrop>().SpawnDropItem();
         GameObject.Destroy(child.gameObject); 
      }
      
   }
}
