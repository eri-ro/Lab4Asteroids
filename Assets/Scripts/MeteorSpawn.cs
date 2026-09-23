using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;

    public int meteorCount = 0;
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }
    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }
}
