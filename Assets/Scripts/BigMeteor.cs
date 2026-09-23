using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : MonoBehaviour
{
    private int hitCount = 0;

    public Vector3 orbitCenter = Vector3.zero;
    public float orbitSpeed = 2f;

    private float radius;
    private float angle;

    void Start()
    {
        Vector3 offset = transform.position - orbitCenter;
        orbitSpeed = Random.Range(-orbitSpeed, orbitSpeed);
        radius = offset.magnitude;
        angle = Mathf.Atan2(offset.y, offset.x);
    }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;

        float x = orbitCenter.x + Mathf.Cos(angle) * radius;
        float y = orbitCenter.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, transform.position.z);

        if (hitCount >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
