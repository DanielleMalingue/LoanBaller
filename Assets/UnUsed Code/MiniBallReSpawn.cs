using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBallReSpawn : MonoBehaviour
{
    


    public GameObject respawnPrefab; // Prefab to respawn
    public GameObject targetGameObject; // Target GameObject to float towards
    public float respawnInterval = 5f; // Time interval between respawns
    public float moveSpeed = 1f; // Speed at which the balls move towards the target

    private float lastSpawnTime; // Time when the last respawn occurred

    void Update()
    {
        // Check if it's time to respawn
        if (Time.time - lastSpawnTime >= respawnInterval)
        {
            // Spawn a new ball at the top left of the screen
            GameObject newBall = Instantiate(respawnPrefab, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)), Quaternion.identity);
            lastSpawnTime = Time.time; // Update the last spawn time

            // Move the spawned ball towards the target GameObject
            MoveTowardsTarget(newBall);
        }
    }

    // Move the ball towards the target GameObject
    void MoveTowardsTarget(GameObject ball)
    {
        if (targetGameObject != null)
        {
            Vector3 targetPosition = targetGameObject.transform.position;
            Vector3 direction = (targetPosition - ball.transform.position).normalized;
            ball.transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}

