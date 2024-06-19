using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float obstacleInterval = 2f;
    public float obstacleSpeed = 0f;
    public float obstacleOffSetX = 0f;
    public Vector2 obstacleOffSetY = new Vector2(0f, 0f);
    public List<GameObject> obstacleListPrefabs;
    [HideInInspector] public int gameScore = 0;
    private bool isGameOver = false;

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void GameOver()
    {
        //Get GameManager
        var gameManager = GameManager.Instance;

        //Ignorar se GameOver
        if (gameManager.IsGameOver())
        {
            return;
        }

        isGameOver = true;

        PlayerController.thisRigidBody.AddForce(new Vector3(-10, 40, 0), ForceMode.Impulse);
        Debug.Log("GAME OVER");

        //Reiniciar Jogo
        StartCoroutine(RestartGame(5));
    }

    private IEnumerator RestartGame(float time)
    {
        yield return new WaitForSeconds(time);

        //Recarregar Scene
        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }
}
