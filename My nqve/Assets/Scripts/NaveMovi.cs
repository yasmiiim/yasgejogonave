using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMovi : MonoBehaviour
{
    public Rigidbody2D rig;
    
    public GameObject laserDoPlayer;
    public Transform localDeDisparo1;
    
    public float velocidadeDaNave;

    public bool contemLaserDuplo;
    
    private Vector2 teclasApertadas;
    
    void Start()
    {
        contemLaserDuplo = false;
    }

   
    void Update()
    {
        Mov();
        ExecutarLaser();
    }

    private void Mov()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * velocidadeDaNave;
    }

    private void ExecutarLaser()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (contemLaserDuplo == false)
            {
                Instantiate(laserDoPlayer, localDeDisparo1.position, localDeDisparo1.rotation);
            }
        }
    }
    
    
}
