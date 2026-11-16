
using UnityEngine;

public class SpriteClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
