using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0;
    void Start()
    {

    }

    void Update()
    {
        //Get GameManager
        var gameManager = GameManager.Instance;

        //Ignore if GameOver
        if (gameManager.IsGameOver())
        {
            return;
        }

        //Update cooldown
        cooldown -= Time.deltaTime;

        if (cooldown <= 0f)
        {
            cooldown = gameManager.obstacleInterval;

            //Spawn Obstacles
            int prefabIndex = Random.Range(0, gameManager.obstacleListPrefabs.Count);

            GameObject prefab = gameManager.obstacleListPrefabs[prefabIndex];

            float x = gameManager.obstacleOffSetX;
            float y = Random.Range(gameManager.obstacleOffSetY.x, gameManager.obstacleOffSetY.y);
            float z = -2f;

            Vector3 position = new Vector3(x, y, z);

            Quaternion rotation = prefab.transform.rotation;

            Instantiate(prefab, position, rotation);
        }
    }
}
