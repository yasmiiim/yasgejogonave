using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMovi : MonoBehaviour
{
    public Rigidbody2D rig;
    
    public float velocidadeDaNave;
    
    private Vector2 teclasApertadas;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        Mov();
    }

    private void Mov()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * velocidadeDaNave;
    }
}
