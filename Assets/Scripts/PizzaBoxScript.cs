using UnityEngine;

public class PizzaBoxScript : MonoBehaviour
{
    public GameObject closedBox;


    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pizza") &&
            collision.gameObject.GetComponent<PizzaScript>().isCut)
        {
            Instantiate(closedBox, transform.position, transform.rotation); 
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
