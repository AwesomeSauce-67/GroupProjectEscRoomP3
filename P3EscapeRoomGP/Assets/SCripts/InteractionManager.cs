
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Camera mainCamera;

    private GameObject heldObject;
    private Collider2D heldCollider;

    void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Move held object with mouse
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

        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        Vector3 mousePosition =
            mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 position = mousePosition;

        // Find all objects under the mouse
        Collider2D[] hits = Physics2D.OverlapPointAll(position);

        if (hits.Length == 0)
        {
            Debug.Log("Nothing clicked!");
            return;
        }

        // PICK UP
        if (heldObject == null)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Interactable"))
                {
                    heldObject = hit.gameObject;
                    heldCollider = heldObject.GetComponent<Collider2D>();

                    Debug.Log("PICKED UP: " + heldObject.name);
                    return;
                }
            }

            return;
        }

        // FIND TARGET, IGNORING HELD ITEM
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == heldObject)
                continue;

            InteractableObject target =
                hit.GetComponentInParent<InteractableObject>();

            if (target != null && target.gameObject != heldObject)
            {
                Debug.Log("Using " + heldObject.name + " on " + target.name);

                GameObject itemToUse = heldObject;

                heldObject = null;
                heldCollider = null;

                target.PerformAction(itemToUse);

                return;
            }
        }
    }
}
