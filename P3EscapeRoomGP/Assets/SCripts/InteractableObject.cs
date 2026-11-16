
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string requiredItemName;

    public void PerformAction(GameObject usedObject)
    {
        if (usedObject.name == requiredItemName ||
            usedObject.name == requiredItemName + "(Clone)")
        {
            Debug.Log("Correct item used!");

            // Destroy the world object
            Destroy(gameObject);

            // Destroy the held item
            Destroy(usedObject);
        }
        else
        {
            Debug.Log("Wrong item!");
        }
    }
}
