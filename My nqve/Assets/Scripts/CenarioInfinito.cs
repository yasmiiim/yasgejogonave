using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CenarioInfinito : MonoBehaviour
{
    public float velocidadeDoCenario;

   
    void Start()
    {

    }

    
    void Update()
    {
        MovimentarCnr();
    }

    private void MovimentarCnr()
    {
        Vector2 deslocamento = new Vector2(Time.time * velocidadeDoCenario, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }

}
