using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private GameController gameController;

    [SerializeField]
    private int points = 0;

    [SerializeField]
    private bool isDeath = false;

    [SerializeField]
    private bool isBad = false;

    [SerializeField]
    private ParticleSystem explosionParticles;


    private float leftSpawnRange = -7.0f;
    private float rightSpawnRange = 5.0f; 

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(leftSpawnRange, rightSpawnRange), -3); 
    }

    // Update is called once per frame
    void Update()
    {
        //The faster you retrieve points the better it is
    }

    void OnMouseDown()
    {
        if(gameController.isGameOver)
        {
            return; 
        }
        Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
        Destroy(gameObject);
        if(isDeath)
        {
            gameController.GameOver(); 
        }
        gameController.UpdatePoints(this.points);
        if (isBad)
        {
            gameController.SetStreak(0);
        }
        else
        {
            gameController.IncreaseStreak(1);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(gameController.isGameOver)
        {
            return; 
        }
        if (!isBad)
        {
            gameController.MissedBall(this.points);
        }
    }


}
