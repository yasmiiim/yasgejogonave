using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{

    public GameObject[] paraSpawnar;

    public Transform[] pontosDeSpawn;

    public float tempoMaxSpawns;

    public float tempoAtualSpawns;
    // Start is called before the first frame update
    void Start()
    {
        tempoAtualSpawns = tempoMaxSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualSpawns -= Time.deltaTime;

        if (tempoAtualSpawns <= 0)
        {
            Spawnar();
        }
    }

    private void Spawnar()
    {
        int ObjAleatorio = Random.Range(0, paraSpawnar.Length);
        int ptsAleatorio = Random.Range(0, pontosDeSpawn.Length);

        Instantiate(paraSpawnar[ObjAleatorio], pontosDeSpawn[ptsAleatorio].position, Quaternion.Euler(0f, 0f, -90f));
        tempoAtualSpawns = tempoMaxSpawns;
    }
}
