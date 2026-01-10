using UnityEngine;

public class CheckScript : MonoBehaviour
{
    // Índices:
    // 0 = Pineapple
    // 1 = Pepe
    // 2 = Fish
    // 3 = Pepper
    // 4 = Mushroom
    // 5 = Olive

    private bool isCorrect = true;
    private bool[] hasIngredients = new bool[6];

    private OrderScript order;

    private void Start()
    {
        order = GameObject.FindGameObjectWithTag("Order")
                          .GetComponent<OrderScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckTrigger"))
        {
            // Limpa antes de verificar (importante)
            for (int i = 0; i < hasIngredients.Length; i++)
                hasIngredients[i] = false;

            foreach (Transform child in transform)
            {
                if (child.CompareTag("Pineapple")) hasIngredients[0] = true;
                else if (child.CompareTag("Pepe")) hasIngredients[1] = true;
                else if (child.CompareTag("Fish")) hasIngredients[2] = true;
                else if (child.CompareTag("Pepper")) hasIngredients[3] = true;
                else if (child.CompareTag("Mushroom")) hasIngredients[4] = true;
                else if (child.CompareTag("Olive")) hasIngredients[5] = true;
            }

            isCorrect = true;

            for (int i = 0; i < hasIngredients.Length; i++)
            {
                bool isRequested =
                    i == order.currentIngredient1 ||
                    i == order.currentIngredient2 ||
                    i == order.currentIngredient3;

                if (isRequested && !hasIngredients[i])
                {
                    Debug.Log("falta " + i);
                    // Falta ingrediente pedido
                    isCorrect = false;
                    break;
                }

                if (!isRequested && hasIngredients[i])
                {
                    Debug.Log("extra " + i);
                    // Ingrediente extra
                    isCorrect = false;
                    break;
                }
            }

            Debug.Log("Pedido correto? " + isCorrect);
        }
    }
}
