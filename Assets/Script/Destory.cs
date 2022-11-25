using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private GameObject players;
   [SerializeField] private int healdown = 50;
   [SerializeField] private string _nextSceneName;
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
         Destroy(player.gameObject);
         LoadingSceneContoller.instance.LoadNextScene(_nextSceneName);
         Debug.Log("HIT");
      }
   }
}
