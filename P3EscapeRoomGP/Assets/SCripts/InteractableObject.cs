
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string requiredItemName;
    public SoundManager soundManager;
    public string soundName;

    public void PerformAction(GameObject usedObject)
    {
        if (usedObject.name == requiredItemName ||
            usedObject.name == requiredItemName + "(Clone)")
        {
            // Play interaction sound
            if (soundManager != null)
            {
                soundManager.PlaySound(soundName);
            }

            // Destroy the world object
            Destroy(gameObject);

            // Destroy the held item
            Destroy(usedObject);
        }
    }
}
