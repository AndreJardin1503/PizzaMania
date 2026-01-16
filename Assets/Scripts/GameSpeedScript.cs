using UnityEngine;

public class GameSpeedScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float pizzaSpeed;
    public float exitSpeed;
    public float ovenSpeed;

    public int totalScore = 0;

    void Start()
    {
        pizzaSpeed = 0.4f;
        exitSpeed = 0.3f;
        ovenSpeed = 1f;
    }


    public void IncrementPizzaSpeed()
    {
        pizzaSpeed += 0.05f;
        exitSpeed += 0.05f;
        ovenSpeed += 0.05f;
    }


}
