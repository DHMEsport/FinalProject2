 using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
 using TMPro;
 using UnityEngine;

public class ITEM : MonoBehaviour
{
  [SerializeField] private GameObject heal;
  private Inventory inventory;
  public GameObject itemButtom;
  private TextMeshPro text;
  private void Start()
  {
    inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
  }
  

  private void OnTriggerEnter(Collider cor)
  {
    if (cor.CompareTag("Player"))
    {
      Destroy(heal.gameObject);
      Debug.Log("Is HIT");
      for (int i = 0; i < inventory.slot.Length; i++)
      {
          if (inventory.isFull[i] == false)
          {
            inventory.isFull[i] = true;
            Instantiate(itemButtom,inventory.slot[i].transform,false);
            Destroy(gameObject);
            break;
          }
      }
    }
  }
}
