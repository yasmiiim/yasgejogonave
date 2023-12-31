using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoPlayer : MonoBehaviour
{
    public GameObject impactoDoLaserPlayer;
    
    public float speedLaser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoviLaser();
    }

    private void MoviLaser()
    {
        transform.Translate(Vector3.up * speedLaser * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemys>().ReceberDano();

            Instantiate(impactoDoLaserPlayer, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
