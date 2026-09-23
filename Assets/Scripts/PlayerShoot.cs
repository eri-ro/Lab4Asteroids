using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public InputActionReference attackInput;
    public float fireRate = 1f;

    float sinceLastShot = 0;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
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
