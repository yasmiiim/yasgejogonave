using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text textoDePontuacao;
    
    public int pontuacaoAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        pontuacaoAtual = 0;
        textoDePontuacao.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        instance = this;
    }

    public void AumentarPontuação(int ganharPontos)
    {
        pontuacaoAtual += ganharPontos;
        textoDePontuacao.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }
}
