
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public SoundManager soundManager;
    public string soundName;

    void OnMouseDown()
    {
        Debug.Log("SPRITE CLICKED!");

        if (soundManager != null)
        {
            Debug.Log("Calling SoundManager!");
            soundManager.PlaySound(soundName);
        }
        else
        {
            Debug.LogError("SoundManager is not assigned!");
        }
    }
}
