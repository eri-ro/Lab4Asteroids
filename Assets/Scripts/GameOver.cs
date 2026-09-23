using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public bool gameOver = false;

    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }
    }
}
