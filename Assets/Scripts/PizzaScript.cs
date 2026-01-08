using UnityEngine;
using UnityEngine.UIElements;

public class PizzaScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, -0.1f);
    }
}
