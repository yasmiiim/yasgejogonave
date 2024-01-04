using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            AtivarEnemy();
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
        Destroy(gameObject, 1f);
        
    }
}
