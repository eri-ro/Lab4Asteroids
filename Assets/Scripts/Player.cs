using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    private float speed = 6f;
    public InputActionReference moveInput;
    public InputActionReference attackInput;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    public float fireRate = 1f;

    float sinceLastShot = 0;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        //attackInput.action.performed += Shooting;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (sinceLastShot > 0)
        {
            sinceLastShot -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
        }

        if (attackInput.action.IsPressed())
            {
                Shooting();
            }
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

    void Shooting()
    {
        if (canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            sinceLastShot = fireRate;
        }
    }
}
