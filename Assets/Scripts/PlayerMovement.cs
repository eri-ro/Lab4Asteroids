using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

#region Inspector

    public GameObject laserPrefab;

#endregion
#region Variables

    private float speed = 6f;
    public InputActionReference moveInput;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
  
#endregion
#region Update

    // Checks for movement input each frame
    void Update()
    {
        Movement();
    }

#endregion
#region Movement

    void Movement()
    {
        // Reads New Input System
        float horInput = moveInput.action.ReadValue<Vector2>().x;
        float vertInput = moveInput.action.ReadValue<Vector2>().y;

        transform.Translate(new Vector3(horInput, vertInput, 0) * Time.deltaTime * speed);

        // End of screen transitions
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

#endregion

}
