using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeInimigos : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D coll)
   {
      if (coll.gameObject.CompareTag("Enemy"))
      {
         coll.gameObject.GetComponent<Enemys>().AtivarEnemy();
      }
   }
}
