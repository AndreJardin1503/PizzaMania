using UnityEngine;

public class PizzaBoxClosed : MonoBehaviour

{
    private Transform spawnPoint;
    public GameObject box;
    public bool isRightOrder;

    private void Awake()
    {
        spawnPoint = GameObject.FindWithTag("PizzaBoxSpawn").transform;
    }

    private void OnDestroy()
    {
        spawnPoint = GameObject.FindWithTag("PizzaBoxSpawn").transform;
        GameObject aa = Instantiate(
            box,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            this.transform.position = spawnPoint.position;
        }
    }

}
