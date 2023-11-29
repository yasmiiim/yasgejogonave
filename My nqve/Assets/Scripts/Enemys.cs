using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{

    public GameObject laserEnemy;
    public Transform localDisparo;
    public Transform disparo2;
    public Transform disparo3;
        
    public float speedEnemy;

    public float tempoMaxLaser;
    public float tempoAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoviEnemy();
        Atirar();
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
            Instantiate(laserEnemy, disparo2.position, Quaternion.Euler(0f, 0f, 90f));
            Instantiate(laserEnemy, disparo3.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtual = tempoMaxLaser;
        }
    }
}
