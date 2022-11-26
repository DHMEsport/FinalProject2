using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{   
  [SerializeField] private float lookRadius;
  [SerializeField] private float speed;
  [SerializeField] private Transform playertarget;
  [SerializeField] private float minimumdistance;
  [SerializeField] private int healdown;
  [SerializeField] private GameObject Enemy;
  private GameContoller gc;
  private void Start()
  {
    GameObject go = GameObject.FindGameObjectWithTag("GameController");
    if (go != null)
    {
      gc = go.GetComponent<GameContoller>();
    }
  }

  private void Update()
  {
    float distance = Vector3.Distance(playertarget.position, transform.position);
    if (Vector3.Distance(transform.position,playertarget.position)>minimumdistance)
    {
      if (distance <= lookRadius)
      {
        transform.position = Vector3.MoveTowards(transform.position, playertarget.position, speed * Time.deltaTime);
        transform.LookAt(playertarget);
        Debug.Log("See target");
      }
    }
  }
 

  private void OnTriggerEnter(Collider col)
  {
    if (col.CompareTag("Player"))
    {
      gc.UpdateHeal(-healdown);
      Debug.Log("HIT");
    }
    
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position,lookRadius);
  }
}

