using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private int heal = 100;
    private int live = 1;
    private GameContoller gc;
    public void UpdateHeal(int change)
    {
        heal += change;
        UpdateHealLive();
        Heal();
    }
    public void UpdateLive(int change)
    {
        live += change;
        UpdateLive();
    }

    public void UpdateHealLive()
    {
        Debug.Log($"You have heal" +heal);
    }

    public void UpdateLive()
    {
        Debug.Log($"Your live " + live);
    }

    public void Heal()
    {
        UpdateLive();
        if (heal <= 0)
        {
            if (live >= 1)
            {
                live = live - 1;
                UpdateLive();
            }

            if (live <= 0)
            {
                Destroy(this.Player);
            }
        }
    }
}
