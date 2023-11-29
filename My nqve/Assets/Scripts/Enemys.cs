using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public float speedEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoviEnemy();
    }

    private void MoviEnemy()
    {
        transform.Translate(Vector3.down * speedEnemy * Time.deltaTime);
    }
}
