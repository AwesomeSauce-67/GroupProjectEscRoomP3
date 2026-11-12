
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public void PerformAction(GameObject usedObject)
    {
        Debug.Log(
            usedObject.name + " was used on " + gameObject.name
        );

        // YOUR OBJECT ACTION GOES HERE

        Debug.Log(gameObject.name + " performed its action!");
    }
}
