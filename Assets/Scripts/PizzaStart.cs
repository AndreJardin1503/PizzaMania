using UnityEngine;
using System;
using Oculus.Interaction.Editor;

public class PizzaStart : MonoBehaviour
{
    public GameObject pizza;

    private void OnCollisionEnter(Collision collision)
    {
        //Transform pizzaSpawner = transform.Find("Dropper/Cabeca");
        //spawner = pizzaSpawner.gameObject.GetComponent<PizzaSpawner>();

        PizzaSpawner spawner = FindFirstObjectByType<PizzaSpawner>();

        Instantiate(
            pizza,
            new Vector3(transform.position.x, transform.position.y - 0f, transform.position.z),
            transform.rotation
        );

        Destroy(spawner.s);
    }

}
