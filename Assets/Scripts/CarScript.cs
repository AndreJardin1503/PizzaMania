using UnityEngine;

public class CarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float speed = 40;
    float exitSpeed;
    private bool isStopping = false;
    private bool hasPizza = false;

    private CarSpawnScript spawnScript;
    private GameSpeedScript speedScript;

    void Start()
    {
        exitSpeed = speed;
        spawnScript = GameObject.FindWithTag("CarSpawner").GetComponent<CarSpawnScript>();
        speedScript = GameObject.FindWithTag("GameManager").GetComponent<GameSpeedScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopping && speed > 0)
        {
            speed -= 0.4f;
        }

        if (speed > 0)
        {
            transform.position += Vector3.left * speed / 1000;
        }


        if (hasPizza) 
        {
            transform.position += Vector3.left * exitSpeed / 1000;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarTrigger"))
        {
            isStopping = true;
        }
        if (other.CompareTag("CarDeleteTrigger"))
        {
            Destroy(gameObject);
            spawnScript.SpawnCar();
            speedScript.IncrementPizzaSpeed();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ClosedBox"))
        {
            Destroy(collision.gameObject);
            hasPizza = true;
        }
    }
}
