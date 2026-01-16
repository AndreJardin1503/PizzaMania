using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public class StickToPizzaScript : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject missVfx;
    public GameObject hitVfx;

    public GameObject ingredientPrefab;
    private Animator animator;

    private bool isOnPizza = false;


    private void Start()
    {
        isOnPizza = false;
        transform.localScale = Vector3.one * 2.5f;
        animator = GetComponent<Animator>();
        animator.SetTrigger("spawn");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pizza")
        {
            if (isOnPizza) return;
             

            transform.SetParent(collision.transform);
            //transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            isOnPizza = true;
            Instantiate(hitVfx, transform.position, transform.rotation);
            Debug.Log("hai com " + collision.collider.name);
            Instantiate(ingredientPrefab, spawnPoint.position, spawnPoint.rotation);

            this.GetComponent<Rigidbody>().isKinematic = true;
            animator.enabled = false;
            return;

        }
        if (collision.collider.tag != "Mesa" && collision.collider.gameObject.layer != LayerMask.NameToLayer("Ingredients") && !isOnPizza)
        {
            Instantiate(missVfx, transform.position, transform.rotation);

            this.transform.position = spawnPoint.transform.position;
            this.transform.rotation = spawnPoint.transform.rotation;
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            

            

        }
    }

}


