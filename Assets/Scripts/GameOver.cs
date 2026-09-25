using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

#region Inspector

    [Tooltip("R to restart")]
    public InputActionReference restartAction;
    public bool gameOver = false;

#endregion
#region Update

    void Update()
    {
        // Checks if the restart button was pressed every frame.
        if (gameOver)
        {
            CancelInvoke();
        }
        if (restartAction.action.IsPressed() && gameOver)
        {
            // Reloads the scene.
            SceneManager.LoadScene("Week5Lab");
        }
    }

#endregion

}
