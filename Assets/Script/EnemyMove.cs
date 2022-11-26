using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
  [SerializeField] private float lookRadius;

//   [SerializeField] private float speed;
//   [SerializeField] private Transform playertarget;
  [SerializeField] private float minimumdistance;
  [SerializeField] private int healdown;
  [SerializeField] private int healmax = 100;
  [SerializeField] private int swordhealdown;
  private int maxheal = 100;
  [SerializeField] private Transform playergameobject;
  private NavMeshAgent enemynevmesh;

  private int currentheal;

//   private HealBar heal;
  private GameContoller gc;

  private void Start()
  {
    GameObject go = GameObject.FindGameObjectWithTag("GameController");
    if (go != null)
    {
      gc = go.GetComponent<GameContoller>();
    }

    StartCoroutine(setdistance());
    enemynevmesh = GetComponent<NavMeshAgent>();
  }
  
  void Update()
  {
    setdistance();
  }

  IEnumerator setdistance()
  {
    float distance = Vector3.Distance(playergameobject.position, transform.position);
    if (Vector3.Distance(transform.position, playergameobject.position) > minimumdistance)
    {
      if (distance <= lookRadius)
      {
        enemynevmesh.SetDestination(playergameobject.position);
        Debug.Log("Navemesh is active and see the player");
        yield return new WaitForSeconds(2f);
        Debug.Log(typeof(WaitForSeconds));
      }
    }
  }

//   private bool isattcking;
//   private void Start()
//   {
//     GameObject go = GameObject.FindGameObjectWithTag("GameController");
//     if (go != null)
//     {
//       gc = go.GetComponent<GameContoller>();
//     }
//   }
//
//   private void Update()
//   {
//     float distance = Vector3.Distance(playertarget.position, transform.position);
//     if (Vector3.Distance(transform.position,playertarget.position)>minimumdistance)
//     {
//       if (distance <= lookRadius)
//       {
//         transform.position = Vector3.MoveTowards(transform.position, playertarget.position, speed * Time.deltaTime);
//         facetarget();
//         Debug.Log("See target");
//       }
//     }
//   }
//
  void facetarget()
  {
    Vector3 direction = (playergameobject.position - transform.position).normalized;
    Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime);
    Debug.Log("face is rotation to player");
  }
//   
//   

  private void nTriggerEnter(Collider col)
  {
    if (col.CompareTag("Player"))
    {
      gc.UpdateHeal(-healdown);
      HealBar.health -= healdown;
      Debug.Log("HIT");
    }

    if (col.CompareTag("sword"))
    {
      healmax = (healmax - swordhealdown);
      if (healmax <= 0)
      {
        Destroy(this.gameObject);
        Destroy(GetComponent<BoxCollider>());
      }

      Debug.Log($"is a {healmax} ");
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, lookRadius);
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, minimumdistance);
  }
}

