using System;
using TMPro;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float speed = 15;
    float exitSpeed;
    private bool isStopping = false;
    private bool hasPizza = false;

    private CarSpawnScript spawnScript;
    private GameSpeedScript speedScript;
    private TMP_Text score;

    public GameObject angryVfx;
    public GameObject happyVfx;
    private Transform vfxTransform;

    private Animator animator;
    private PizzaSpawner pizzaSpawner;

    void Start()
    {
        exitSpeed = speed;
        spawnScript = GameObject.FindWithTag("CarSpawner").GetComponent<CarSpawnScript>();
        speedScript = GameObject.FindWithTag("GameManager").GetComponent<GameSpeedScript>();
        score = GameObject.FindWithTag("ScoreBoard").GetComponent<TMP_Text>();
        vfxTransform = GameObject.FindWithTag("VfxTransform").transform;
        pizzaSpawner = GameObject.FindWithTag("PizzaSpawner").GetComponent<PizzaSpawner>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStopping && speed > 0)
        {
            speed -= 0.5f;
        }

        if (speed > 0)
        {
            transform.position += Vector3.left * speed / 100;
        }


        if (hasPizza) 
        {
            transform.position += Vector3.left * exitSpeed / 100;
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
            pizzaSpawner.CreatePizza();

            if (collision.gameObject.GetComponent<PizzaBoxClosed>().isRightOrder)
            {        
                
                speedScript.totalScore++;
                score.text = $"{speedScript.totalScore}00 ";
                Instantiate(happyVfx, vfxTransform.position, transform.rotation);
                animator.SetTrigger("pop");
            }

            else
            {
                hasPizza = true;
                Instantiate(angryVfx, vfxTransform.position, transform.rotation);
            }
        }
    }

    public void Go()
    {
        animator.enabled = false;  
        hasPizza = true;
    }
}
