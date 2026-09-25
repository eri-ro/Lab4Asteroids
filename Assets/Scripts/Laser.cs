using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

#region Update


    void Update()
    {
        // Moves the laser and destroys it if it goes off screen
        transform.Translate(Vector3.up * Time.deltaTime * 8f);

        if (transform.position.y > 11f)
        {
            Destroy(this.gameObject);
        }
    }

#endregion

}
