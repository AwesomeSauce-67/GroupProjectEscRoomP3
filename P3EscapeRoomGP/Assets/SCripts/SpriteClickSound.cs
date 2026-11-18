
using UnityEngine;

public class SpriteClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
        audioSource.volume = 1f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition =
                mainCamera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit =
                Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null &&
                hit.collider.gameObject == gameObject)
            {
                if (clickSound != null)
                {
                    audioSource.PlayOneShot(clickSound);
                }
            }
        }
    }
}
