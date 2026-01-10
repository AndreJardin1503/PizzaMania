using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    List<int> ingredients = new List<int> { 0, 1, 2, 3, 4, 5 };

    public int currentIngredient1;
    public int currentIngredient2;
    public int currentIngredient3;

    private string[] ingredientNames =
    {
    "Pineapple", //0
    "Peperoni",      //1
    "Fish",      //2
    "Pepper",    //3
    "Mushroom",  //4
    "Olive"      //5
    };

    private void Start()
    {
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

    }
}
