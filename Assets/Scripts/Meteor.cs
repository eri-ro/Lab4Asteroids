using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

#region Inspector

    public Vector3 orbitCenter = Vector3.zero;
    [Tooltip("How fast the meteor's spin around 0.")]
    public float orbitSpeed = 2f;
    [Tooltip("How many lives the player has.")]
    public float hitsRequired = 1;

#endregion
#region Variables

    private int hitCount = 0;
    private float radius;
    private float angle;

#endregion
#region Start

    // controls how the meteors move around 0
    void Start()
    {
        Vector3 offset = transform.position - orbitCenter;

        orbitSpeed = Random.Range(-orbitSpeed, orbitSpeed);
        radius = offset.magnitude;
        angle = Mathf.Atan2(offset.y, offset.x);
    }

#endregion
#region Update

    // controls how the meteors move around 0 each frame
    public virtual void Update()
    {
        angle += orbitSpeed * Time.deltaTime;

        float x = orbitCenter.x + Mathf.Cos(angle) * radius;
        float y = orbitCenter.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, transform.position.z);

        // mega meteor spawn
        if (hitCount >= hitsRequired)
        {
            GameObject.Find("MeteorSpawn").GetComponent<MeteorSpawn>().meteorCount++;
            Destroy(this.gameObject);
        }
    }

#endregion
#region Player Death

    // Player dies through collision
    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameOver>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            Destroy(whatIHit.gameObject);
            hitCount++;
        }
    }

#endregion

}