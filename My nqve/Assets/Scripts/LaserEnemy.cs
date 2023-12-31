using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public GameObject imapctoLaserEnemy;
    
    public float SpeedLaser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveLaser();
    }

    private void MoveLaser()
    {
        transform.Translate(Vector3.up * SpeedLaser * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerVida>().ReceberDano();

            Instantiate(imapctoLaserEnemy, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
