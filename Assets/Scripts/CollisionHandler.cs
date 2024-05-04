using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int loadLevelDelay = 2;
    [SerializeField] AudioClip destroyedSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    AudioSource myAudioSource;

    bool isLoading = false;
    bool debugCollisionsEnabled = true;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update() {
        processDebugKeys();
    }

    void processDebugKeys() {
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C)) {
                debugCollisionsEnabled = !debugCollisionsEnabled;

        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (isLoading || !debugCollisionsEnabled) { return; }
        if (!debugCollisionsEnabled) { return; }

        switch (collisionInfo.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isLoading = true;
        myAudioSource.PlayOneShot(successSound);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadLevelDelay);
    }
    void StartCrashSequence()
    {
        isLoading = true;
        myAudioSource.PlayOneShot(destroyedSound);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadLevelDelay);
    }
    void ReloadLevel()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }

    void LoadNextLevel()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings - 1 == activeScene)
        {
            SceneManager.LoadScene(0);
        } 
        else 
        {
            SceneManager.LoadScene(activeScene + 1);
        }
    }

}
