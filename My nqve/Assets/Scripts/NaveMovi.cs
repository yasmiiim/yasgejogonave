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
        float movimentoVertical = Input.GetAxisRaw("Vertical");
        Vector2 direcaoMovimento = new Vector2(0f, movimentoVertical); 

        rig.velocity = direcaoMovimento.normalized * velocidadeVertical;
    }


    private void ExecutarLaser()
    {
       
        if(Input.GetButtonDown("Fire1"))
        {
            sound.Play();
            
            if (contemLaserDuplo == false)
            {
                Instantiate(laserDoPlayer, localDeDisparo1.position, localDeDisparo1.rotation);
            }
            else
            {
                Instantiate(laserDoPlayer, localDeDisparo2.position, localDeDisparo2.rotation);
                Instantiate(laserDoPlayer, localDeDisparo3.position, localDeDisparo3.rotation);
            }
        }
    }

    private void DesativarLaserDuplo()
    {
        contemLaserDuplo = false;
        tempoAtualDoLaserDupo = tempoMaxDoLaserDuplo;
    }
    
    
}
