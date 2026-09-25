using Unity.Cinemachine;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{

#region Inspector

    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    // Spawns a big meteor when reaches 5
    public int meteorCount = 0;

#endregion
#region Start

    void Start()
    {
        // Starts off with meteors
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

#endregion
#region Update

    void Update()
    {
        // Checks per frame if the big meteor can spawn
        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }

#endregion
#region Spawn Meteor

    // Brings new meteors into the scene.
    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

#endregion
#region Big Meteor Spawn

    // Brings the big meteor into the scene.
    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

#endregion

}
