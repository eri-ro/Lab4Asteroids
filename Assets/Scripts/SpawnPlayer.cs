using Unity.Cinemachine;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;         // Player game object prefab
    public CinemachineCamera CineCamera;    // Cinemachine Camera object


    void Spawn()
    {
        GameObject SpawnedPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);  // Spawn the player in the center of the screen

        CineCamera.Follow = SpawnedPlayer.transform;    // Attach the cinemachine camera to them
    }
}
