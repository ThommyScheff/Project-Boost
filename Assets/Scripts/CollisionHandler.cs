using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        switch (collisionInfo.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly!!!");
                break;
            case "Finish":
                Debug.Log("You've finished the level congrats!");
                LoadNextLevel(activeScene);
                break;
            default:
                ReloadLevel(activeScene);
                break;
        }
    }

    void ReloadLevel(int activeScene)
    {
        SceneManager.LoadScene(activeScene);
    }

    void LoadNextLevel(int activeScene)
    {
        SceneManager.LoadScene(activeScene + 1);
    }

}
