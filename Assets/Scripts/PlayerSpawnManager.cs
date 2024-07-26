using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform doorSpawnPoint;
    public Transform elevatorSpawnPoint;
    public Transform playerTransform;

    void Start()
    {
        Transform spawnPoint = doorSpawnPoint;

        if (CartManager.Instance.GetHasVisitedFloor2())
        {
            spawnPoint = elevatorSpawnPoint;
        }

        playerTransform.position = spawnPoint.position;
        playerTransform.rotation = spawnPoint.rotation;
    }
}