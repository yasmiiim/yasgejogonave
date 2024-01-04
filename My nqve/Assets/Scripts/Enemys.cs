using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemys : MonoBehaviour
{

    public GameObject laserEnemy;
    public Transform localDisparo;
    
        
    public float speedEnemy;

    public float tempoMaxLaser;
    public float tempoAtual;
    
    public int vidaMax;

    public int vidaAtual;

    public int pontos;

    public bool enemyAtivado;
    
    public GameObject itensDoprar;
    
    public int chances;
    

    [SerializeField] private Animator animator;
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyAtivado = false;
        vidaAtual = vidaMax;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            MoviEnemy();
            Atirar();
        }
    }

    public void AtivarEnemy()
    {
        enemyAtivado = true;
    }

    private void MoviEnemy()
    {
        transform.Translate(Vector3.left * speedEnemy * Time.deltaTime);
    }

    private void Atirar()
    {
        tempoAtual -= Time.deltaTime;

        if(tempoAtual <=0 )
        {
            Instantiate(laserEnemy, localDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtual = tempoMaxLaser;
        }
    }
    
   
    
    public void ReceberDano()
    {
        vidaAtual -= 1;

        if (vidaAtual <=0)
        {
            Die(); 
        }
    }
    
    void Die()
    {
        isDead = true;
        animator.SetTrigger("explosion");

        GameManager.instance.AumentarPontuação(pontos);
        
        int numero = Random.Range(0, 100);
        
        if(numero <= chances)
        {
            Instantiate(itensDoprar, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
        Destroy(gameObject, 1f);
        
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            collisionInfo.gameObject.GetComponent<PlayerVida>().ReceberDano();
            animator.SetTrigger("explosion");
            Destroy(this.gameObject);
        }
    }
}
