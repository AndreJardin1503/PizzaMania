using UnityEngine;

public class CarSpawnScript : MonoBehaviour
{
    public GameObject[] cars;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCar()
    {
        int carNum = Random.Range(0, cars.Length);
        GameObject car = cars[carNum];
        Instantiate(car);
    }
}
