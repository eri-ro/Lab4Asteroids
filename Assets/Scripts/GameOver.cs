using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Tooltip("R to restart")]
    public InputActionReference restartAction;
    public bool gameOver = false;

    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }
        if (restartAction.action.IsPressed() && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }
    }
}
