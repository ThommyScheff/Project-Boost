using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDestroySound : MonoBehaviour
{
    AudioSource myAudioSource;
    void OnCollisionEnter(Collision collisionInfo)
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.Play();
        if (collisionInfo.gameObject.tag == "Player")
        {
            myAudioSource.Play();
        }
    }
}
