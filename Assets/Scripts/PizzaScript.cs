using UnityEngine;

public class PizzaScript : MonoBehaviour
{
    float speed = 0.4f;
    float exitSpeed = 0.3f;

    public Mesh cookedMesh;

    private Animator frontDoorAnimator;
    private Animator sideDoorAnimator;
    private GameSpeedScript gameSpeedManager;

    private float cookTime = 3f;
    private float timer;

    public Material cutPizza;
    public bool isCut = false;

    enum PizzaState { Entering, Cooking, Exiting }
    PizzaState state = PizzaState.Entering;

    void Start()
    {
        frontDoorAnimator = GameObject.FindWithTag("FrontDoor").GetComponent<Animator>();
        sideDoorAnimator = GameObject.FindWithTag("SideDoor").GetComponent<Animator>();
        gameSpeedManager = GameObject.FindWithTag("GameManager").GetComponent<GameSpeedScript>();

        speed = gameSpeedManager.pizzaSpeed;
        exitSpeed = gameSpeedManager.exitSpeed;

        frontDoorAnimator.speed = gameSpeedManager.ovenSpeed;
        sideDoorAnimator.speed = gameSpeedManager.ovenSpeed;

        cookTime -= gameSpeedManager.ovenSpeed;

        if (cookTime < 0.5f)
        {
            cookTime = 0.5f;
        }
        
    }

    void FixedUpdate()
    {
        if (state == PizzaState.Entering)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (state == PizzaState.Cooking)
        {
            timer += Time.deltaTime;

            if (timer >= cookTime)
            {
                MeshFilter meshFilter = GetComponent<MeshFilter>();
                meshFilter.mesh = cookedMesh;

                sideDoorAnimator.SetTrigger("open");
                state = PizzaState.Exiting;
            }
        }

        if (state == PizzaState.Exiting)
        {
            transform.Translate(-exitSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state == PizzaState.Entering && other.CompareTag("FrontTrigger"))
        {
            frontDoorAnimator.SetTrigger("open");
        }

        if (state == PizzaState.Entering && other.CompareTag("OvenTrigger"))
        {
            frontDoorAnimator.SetTrigger("close");
            speed = 0;
            state = PizzaState.Cooking;
        }

        if (state == PizzaState.Exiting && other.CompareTag("ExitTrigger"))
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            sideDoorAnimator.SetTrigger("close");
            exitSpeed = 0;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == PizzaState.Exiting && collision.gameObject.CompareTag("Cutter"))
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material = cutPizza;
            isCut = true;
        }
    }
}


