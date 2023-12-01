using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVida : MonoBehaviour
{
    public int vidaMax;

    public int vidaAtual;


    [SerializeField] private Animator animator;
    [SerializeField] private barraVida barraDeVida;
    private bool isDead = false;
    
    private NaveMovi playerMovimento;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMax;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);
        playerMovimento = GetComponent<NaveMovi>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceberDano()
    {
        vidaAtual -= 1;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaMax);

        if (vidaAtual <=0)
        {
            Die(); 
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
