using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVida : MonoBehaviour
{
    public int vidaMax;
    public int vidaMaxEscudo = 5; 

    public int vidaAtual;
    public int vidaAtualEscudo;

    public GameObject escudo;
    public bool escudoAtivado;

    private Animator anim;

    
    
    


    [SerializeField] private Animator animator;
    [SerializeField] private barraVida barraDeVida;
    private bool isDead = false;
    
    private NaveMovi playerMovimento;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax;
        vidaAtualEscudo = vidaMaxEscudo;
        
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);
        playerMovimento = GetComponent<NaveMovi>();
        
        escudo.SetActive(false);
        escudoAtivado = false;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Awake()
    {
        
    }
    

    public void AtivarEscudo()
    {
        vidaAtualEscudo = vidaMaxEscudo; ;
        
        escudo.SetActive(true);
        escudoAtivado = true;
        anim.SetTrigger("ESCUDOOOOOOOO");
        Debug.Log("ativou");
    }

    public void GanharVidaExtra(int vidaExtra)
    {
        if (vidaAtual + vidaExtra <= vidaMax)
        {
            vidaAtual += vidaExtra;
        }
        else
        {
            vidaAtual = vidaMax;
        }

        //barraDeVida.value = vidaAtual;
    }

    public void ReceberDano()
    {
        if (escudoAtivado == false)
        {
            vidaAtual -= 1;
            barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);

            if (vidaAtual <= 0)
            {
                GameManager.instance.GameOver();
                Die();
               
            }
        }
        
        else
        {
            vidaAtualEscudo -= 1;

            if (vidaAtualEscudo <= 0)
            {
                escudo.SetActive(false);
                escudoAtivado = false;
            }
        }
    }


    void Die()
    {
        isDead = true;
        animator.SetTrigger("playerdie");
        if (playerMovimento != null)
        {
            playerMovimento.enabled = false;
        }

        Destroy(gameObject, 1f);
    }
}
