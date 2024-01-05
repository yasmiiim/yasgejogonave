using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMovi : MonoBehaviour
{
    public Rigidbody2D rig;
    
    public GameObject laserDoPlayer;
    
    public Transform localDeDisparo1;
    public Transform localDeDisparo2;
    public Transform localDeDisparo3;
    public AudioSource sound;
    
    public float velocidadeDaNave;
    public float tempoMaxDoLaserDuplo;
    public float tempoAtualDoLaserDupo;

    public bool contemLaserDuplo;
    
    private Vector2 teclasApertadas;
    
    
    void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    void Start()
    {
        contemLaserDuplo = false;

        tempoAtualDoLaserDupo = tempoMaxDoLaserDuplo;
    }

   
    void Update()
    {
        Mov();
        ExecutarLaser();

        if (contemLaserDuplo == true)
        {
            tempoAtualDoLaserDupo -= Time.deltaTime;

            if (tempoAtualDoLaserDupo <= 0)
            {
                DesativarLaserDuplo();
            }
        }
    }

    public float velocidadeVertical = 8f; 

    private void Mov()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * velocidadeDaNave;
    }


    private void ExecutarLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sound.Play();

            if (!contemLaserDuplo)
            {
                GameObject laser1 = Instantiate(laserDoPlayer, localDeDisparo1.position, localDeDisparo1.rotation);
                DestruirAposTempo(laser1, 1.0f); // Chama a função para destruir após 1 segundo
            }
            else
            {
                GameObject laser2 = Instantiate(laserDoPlayer, localDeDisparo2.position, localDeDisparo2.rotation);
                GameObject laser3 = Instantiate(laserDoPlayer, localDeDisparo3.position, localDeDisparo3.rotation);

                DestruirAposTempo(laser2, 1.0f); // Chama a função para destruir após 1 segundo
                DestruirAposTempo(laser3, 1.0f); // Chama a função para destruir após 1 segundo
            }
        }
    }

// Função para destruir o objeto após um determinado tempo
    private void DestruirAposTempo(GameObject objeto, float tempo)
    {
        Destroy(objeto, tempo);
    }

    private void DesativarLaserDuplo()
    {
        contemLaserDuplo = false;
        tempoAtualDoLaserDupo = tempoMaxDoLaserDuplo;
    }
    
    
}
