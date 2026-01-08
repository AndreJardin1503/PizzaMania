using Oculus.VoiceSDK.UX;
using UnityEngine;

public class PizzaSpawner : MonoBehaviour
{
    public GameObject pizza;
    public Material yellow;
    [HideInInspector] public GameObject s;

    public void CreatePizza()
    {
        s = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        s.transform.position = transform.position;
        s.transform.localScale = Vector3.one * 0.1f;

        MeshRenderer sMesh = s.GetComponent<MeshRenderer>();
        sMesh.material = yellow;

        Rigidbody rb = s.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        PizzaStart pre = s.AddComponent<PizzaStart>();
        pre.pizza = pizza;
        pre.pizza.transform.position = s.transform.position;
    }

    private void Start()
    {
        CreatePizza();
    }
}
