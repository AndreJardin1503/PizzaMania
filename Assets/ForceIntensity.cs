using UnityEngine;

public class ForceIntensity : MonoBehaviour
{

    public float intensidade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyForce () {
        this.GetComponent<RigidBody>().AddForce(Vector3.up*intensidade,ForceMode.Impulse);

    }


}
