
using UnityEngine;

public class HeldItem : MonoBehaviour
{
    public void Use(GameObject targetObject)
    {
        if (targetObject == null)
            return;

        InteractableObject interactable =
            targetObject.GetComponent<InteractableObject>();

        if (interactable != null)
        {
            interactable.PerformAction(gameObject);
        }
    }
}
