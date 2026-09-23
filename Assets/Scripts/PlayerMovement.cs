using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject laserPrefab;

    private float speed = 6f;
    public InputActionReference moveInput;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
  

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horInput = moveInput.action.ReadValue<Vector2>().x;
        float vertInput = moveInput.action.ReadValue<Vector2>().y;

        transform.Translate(new Vector3(horInput, vertInput, 0) * Time.deltaTime * speed);

        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }
}
