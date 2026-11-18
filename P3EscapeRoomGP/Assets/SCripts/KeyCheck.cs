
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public static bool spriteClicked = false;

    private void OnMouseDown()
    {
        spriteClicked = true;
        Destroy(gameObject);
    }
}
