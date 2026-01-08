using UnityEngine;

public class PizzaScript : MonoBehaviour
{
    float speed = 3f;
    float exitSpeed = 2f;

    public Mesh cookedMesh;

    private Animator frontDoorAnimator;
    private Animator sideDoorAnimator;

    private float cookTime = 3f;
    private float timer;

    enum PizzaState { Entering, Cooking, Exiting }
    PizzaState state = PizzaState.Entering;

    void Start()
    {
        frontDoorAnimator = GameObject.FindWithTag("FrontDoor").GetComponent<Animator>();
        sideDoorAnimator = GameObject.FindWithTag("SideDoor").GetComponent<Animator>();
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

        if (state == PizzaState.Entering && other.CompareTag("OvenCenter"))
        {
            frontDoorAnimator.SetTrigger("close");
            speed = 0;
            state = PizzaState.Cooking;
        }

        if (state == PizzaState.Exiting && other.CompareTag("ExitTrigger"))
        {
            sideDoorAnimator.SetTrigger("close");
            exitSpeed = 0;
        }
    }
}
