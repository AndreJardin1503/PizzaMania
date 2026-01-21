using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    List<int> ingredients = new List<int> { 0, 1, 2, 3, 4, 5 };

    private GameObject fishimg;
    private GameObject pepeimg;
    private GameObject oliveimg;
    private GameObject pineimg;
    private GameObject mushimg;
    private GameObject pepperimg;

    private GameObject[] images;

    public int currentIngredient1;
    public int currentIngredient2;
    public int currentIngredient3;

    private string[] ingredientNames =
    {
    "Pineapple", //0
    "Peperoni",  //1
    "Fish",      //2
    "Pepper",    //3
    "Mushroom",  //4
    "Olive"      //5
    };

    private void Start()
    {
        fishimg = GameObject.FindWithTag("ImageFish");
        pepeimg = GameObject.FindWithTag("ImagePepe");
        oliveimg = GameObject.FindWithTag("ImageOlive");
        pineimg = GameObject.FindWithTag("ImagePine");
        mushimg = GameObject.FindWithTag("ImageMush");
        pepperimg = GameObject.FindWithTag("ImagePepper");

        images = new GameObject[]
        {
        pineimg,
        pepeimg,
        fishimg,
        pepperimg,
        mushimg,
        oliveimg      
        };

        Random3Ingredients();
    }

    void Random3Ingredients()
    {
        // Embaralha a lista
        for (int i = 0; i < ingredients.Count; i++)
        {
            int rnd = Random.Range(i, ingredients.Count);
            int temp = ingredients[i];
            ingredients[i] = ingredients[rnd];
            ingredients[rnd] = temp;
        }

        // Pega os 3 primeiros
        currentIngredient1 = ingredients[0];
        currentIngredient2 = ingredients[1];
        currentIngredient3 = ingredients[2];

        Transform textObj = transform.Find("Canvas/Text");
        TMP_Text text = textObj.GetComponent<TMP_Text>();
        text.text =
        $"{ingredientNames[currentIngredient1]}, " +
        $"{ingredientNames[currentIngredient2]}, " +
        $"{ingredientNames[currentIngredient3]}";

        foreach (GameObject i in images)
        {
            i.transform.Find("Cross").gameObject.SetActive(true);
        }

        //images[currentIngredient1].transform.Find("Check").gameObject.SetActive(true);
        images[currentIngredient1].transform.Find("Cross").gameObject.SetActive(false);
        //images[currentIngredient2].transform.Find("Check").gameObject.SetActive(true);
        images[currentIngredient2].transform.Find("Cross").gameObject.SetActive(false);
        //images[currentIngredient3].transform.Find("Check").gameObject.SetActive(true);
        images[currentIngredient3].transform.Find("Cross").gameObject.SetActive(false);


    }

    public void UpdateBoard(bool[] hasIngredients)
    {
        if (hasIngredients[currentIngredient1])
        {
            images[currentIngredient1].transform.Find("Check").gameObject.SetActive(true);
        }
        if (hasIngredients[currentIngredient2])
        {
            images[currentIngredient2].transform.Find("Check").gameObject.SetActive(true);
        }
        if (hasIngredients[currentIngredient3])
        {
            images[currentIngredient3].transform.Find("Check").gameObject.SetActive(true);
        }
    }

    public void ResetBoard()
    {
        for (int i = 0; i < images.Length; i++) 
        {
            images[i].transform.Find("Cross").gameObject.SetActive(false);
            images[i].transform.Find("Check").gameObject.SetActive(false);
        }

        Random3Ingredients();
    }
}
