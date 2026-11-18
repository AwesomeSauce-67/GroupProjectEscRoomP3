
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public string sceneName;

    private void OnMouseDown()
    {
        if (KeyCheck.spriteClicked == true)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
