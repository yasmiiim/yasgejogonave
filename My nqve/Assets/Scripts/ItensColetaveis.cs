using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{

    public bool powerUpEscudo;
    public bool powerUpLaserDuplo;
    public bool powerUpVida;

    public int vidas;
    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (powerUpEscudo == true)
            {
                coll.gameObject.GetComponent<PlayerVida>().AtivarEscudo();
            }

            if (powerUpLaserDuplo == true)
            {
                coll.gameObject.GetComponent<NaveMovi>().contemLaserDuplo = false;

                coll.gameObject.GetComponent<NaveMovi>().tempoAtualDoLaserDupo =
                    coll.gameObject.GetComponent<NaveMovi>().tempoMaxDoLaserDuplo;
               
                coll.gameObject.GetComponent<NaveMovi>().contemLaserDuplo = true;
                Debug.Log("bateu");
            }

            //if (powerUpVida == true)
            //{
               // coll.gameObject.GetComponent<PlayerVida>().GanharVida(vidas);
            //}
            
            Destroy(this.gameObject);
        }
    }
}
