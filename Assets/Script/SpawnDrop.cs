using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDropItem()
    {
        Vector3 playerpos = new Vector3(player.position.x, 0,player.position.z+3);
        Instantiate(item,playerpos, Quaternion.identity);
    }
}
