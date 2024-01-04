using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject[] inimigosParaSpawnar;

    public Transform[] pontosDeSpawn;

    public float tempoMaxSpawns;
    private float tempoAtualSpawns;

    
    void Start()
    {
        tempoAtualSpawns = tempoMaxSpawns;
    }

   
    void Update()
    {
        if (tempoAtualSpawns <= 0)
        {
            SpawnarInimigo();
            tempoAtualSpawns = tempoMaxSpawns; 
        }
        else
        {
            tempoAtualSpawns -= Time.deltaTime;
        }
    }

    private void SpawnarInimigo()
    {
        int inimigoAleatorio = Random.Range(0, inimigosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(inimigosParaSpawnar[inimigoAleatorio], pontosDeSpawn[pontoAleatorio].position, Quaternion.identity);
        tempoAtualSpawns = tempoMaxSpawns;
    }
}
