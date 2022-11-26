using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int healdown = -20;
    [SerializeField] private int healmax = 100;
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
        if (col.CompareTag("Enemy"))
        {
            healmax = healmax - healdown;
            if (healmax <= 0)
            {
                Destroy(Enemy.gameObject);
            }
            Debug.Log($"is a heal" + healmax);
        }
    }
}
