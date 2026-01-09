using System.Collections;
using Unity.VisualScripting;
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

        //StartCoroutine(MyCoroutine());

        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward*intensidade,ForceMode.Impulse);
            print(this.GetComponent<Rigidbody>().linearVelocity);
            print(this.transform.forward);
            print(intensidade);


    }

     IEnumerator MyCoroutine()
    {
        // Loop indefinitely (or until stopped)
        
        
            Debug.Log("Coroutine started: " + Time.time);

            // Wait for 1 second (scaled time)
            yield return new WaitForSeconds(0.2f);

            this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward*intensidade + this.transform.up*intensidade,ForceMode.Impulse);
            print(this.GetComponent<Rigidbody>().linearVelocity);
            print(this.transform.forward);
            print(intensidade);

            Debug.Log("Coroutine resumed after 1 second: " + Time.time);

            // Perform your action here, e.g., instantiate a new object
            // GameObject newObject = Instantiate(myPrefab, transform.position, Quaternion.identity);
    }


}
