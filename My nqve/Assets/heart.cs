using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heart : MonoBehaviour
{
    public int vidaColetada = 20;
    public Image barradeVidaImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerVida playerHealth = collision.GetComponent<PlayerVida>(); 

            if (playerHealth != null)
            {
                playerHealth.GanharVidaExtra(vidaColetada); 
                AtualizarBarraDeVida(playerHealth.vidaAtual, playerHealth.vidaMax); 
                Destroy(gameObject); 
            }
        }
    }

    
    private void AtualizarBarraDeVida(int vidaAtual, int vidaMax)
    {
        if (barradeVidaImage != null)
        {
            barradeVidaImage.fillAmount = (float)vidaAtual / vidaMax;
        }
    }
}
