
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Camera mainCamera;

    private GameObject heldObject;

    void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Move held object
        if (heldObject != null)
        {
            Vector3 mousePosition =
                mainCamera.ScreenToWorldPoint(Input.mousePosition);

            heldObject.transform.position = new Vector3(
                mousePosition.x,
                mousePosition.y,
                heldObject.transform.position.z
            );
        }

        // Handle clicks
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        Vector3 mousePosition =
            mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 position = new Vector2(
            mousePosition.x,
            mousePosition.y
        );

        Collider2D[] hits = Physics2D.OverlapPointAll(position);

        InteractableObject clickedTarget = null;

        // Find an object underneath the cursor
        foreach (Collider2D hit in hits)
        {
            InteractableObject candidate =
                hit.GetComponentInParent<InteractableObject>();

            if (candidate == null)
                continue;

            // Ignore the object currently being held
            if (heldObject != null &&
                candidate.gameObject == heldObject)
                continue;

            clickedTarget = candidate;
            break;
        }

        // PICK UP
        if (heldObject == null)
        {
            if (clickedTarget == null)
                return;

            if (clickedTarget.CompareTag("Interactable"))
            {
                heldObject = clickedTarget.gameObject;
                Debug.Log("PICKED UP: " + heldObject.name);
            }

            return;
        }

        // USE HELD OBJECT ON TARGET
        if (clickedTarget != null)
        {
            Debug.Log("TARGET FOUND: " + clickedTarget.name);

            GameObject itemToDestroy = heldObject;

            clickedTarget.PerformAction(itemToDestroy);

            heldObject = null;

            Destroy(itemToDestroy);

            Debug.Log("ITEM DESTROYED!");
        }
    }
}
