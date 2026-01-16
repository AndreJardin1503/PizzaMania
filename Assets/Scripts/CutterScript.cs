using UnityEngine;

public class CutterScript : MonoBehaviour
{

    public GameObject poofVfx;
    public Transform respawnLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetCutter()
    {
        Instantiate(poofVfx, transform.position, transform.rotation);
        this.transform.position = respawnLocation.position;
    }
}
