using Oculus.Interaction;
using UnityEngine;

public class StickToPizzaScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pizza")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = collision.transform;

        }
    }
}
