// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameStarter : MonoBehaviour
// {
//     private bool gameStarted = false;
//     public GameObject[] gameObjectsToActivate;
//     public PlayerController playerController;
//     public CustomGravity customGravity;

//     void Start()
//     {
//         // Desativa os objetos do jogo inicialmente
//         foreach (GameObject obj in gameObjectsToActivate)
//         {
//             obj.SetActive(false);
//         }

//         // Certifique-se de que o jogador está ativo, mas funcionalidade desativada
//         if (playerController != null)
//         {
//             playerController.gameObject.SetActive(true);
//         }
//     }

//     void Update()
//     {
//         if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
//         {
//             StartGame();
//         }
//     }

//     void StartGame()
//     {
//         gameStarted = true;
        
//         //Ativa os objetos necessários para o jogo
//         foreach (GameObject obj in gameObjectsToActivate)
//         {
//             obj.SetActive(true);
//         }

//         if (playerController != null)
//         {
//             playerController.StartGame();
//         }

//         // Chama o método StartGame do CustomGravity
//         if (customGravity != null)
//         {
//             customGravity.StartGame();
//         }
//     }
// }
