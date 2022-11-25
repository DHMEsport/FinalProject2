using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
   private Image healbar;
   private float maxheal = 100f;
   public static float health;

   private void Start()
   {
      healbar = GetComponent<Image>();
      health = maxheal;
   }

   private void Update()
   {
      healbar.fillAmount = health / maxheal;
   }
}
