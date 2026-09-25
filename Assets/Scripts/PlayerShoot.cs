using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

#region Inspector

    public GameObject laserPrefab;
    public InputActionReference attackInput;
    public float fireRate = 1f;

#endregion
#region Variables

    float sinceLastShot = 0;
    private bool canShoot = true;

#endregion
#region Update

    void Update()
    {
        // Updating the bool, and calling the method that controls fire rate
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

#endregion
#region Shooting

    // Fire rate controls
    // Stored in a seperate method for modularity
    void Shooting()
    {
        if (canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            sinceLastShot = fireRate;
        }
    }

#endregion

}
