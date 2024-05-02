using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("get active scene:" + activeScene);
            SceneManager.LoadScene(activeScene++);
        }
    }
}
