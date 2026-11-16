
using UnityEngine;

public class DisappearAndEnable : MonoBehaviour
{
    public GameObject objectToEnable;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Enable the other GameObject
            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            }

            // Make this item disappear
            gameObject.SetActive(false);
        }
    }
}
