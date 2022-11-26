using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
   [SerializeField] private GameObject Box;
   [SerializeField] private GameObject player;
   [SerializeField] private int healdown = 50;
   private GameContoller gc;
   private void Start()
   {
      GameObject go = GameObject.FindGameObjectWithTag("GameController");
      if (go != null)
      {
         gc = go.GetComponent<GameContoller>();
      }
   }

   private void OnTriggerEnter(Collider col)
   {
      if (col.CompareTag("Player"))
      {
         gc.UpdateHeal(-healdown);
         Destroy(Box.gameObject);
         Debug.Log("HIT");
      }
   }
}
