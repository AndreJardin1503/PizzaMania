using UnityEngine;

public class PizzaBoxScript : MonoBehaviour
{
    public GameObject closedBox;
    public bool isRight;


    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pizza") &&
            collision.gameObject.GetComponent<PizzaScript>().isCut)
        {
            isRight = collision.gameObject.GetComponent<CheckScript>().isCorrect;
            
            GameObject box = Instantiate(closedBox, transform.position, transform.rotation);
            box.GetComponent<PizzaBoxClosed>().isRightOrder = isRight;

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
