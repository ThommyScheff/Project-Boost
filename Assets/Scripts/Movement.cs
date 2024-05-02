using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    Rigidbody myRigidBoy;
    AudioSource myAudioSource;
    Vector3 moveUp = Vector3.up;
    int mainThrust = 1000;
    int rotationSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBoy = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        processThrust();
        processRotation();
    }

    void processThrust() {
        if (Input.GetKey(KeyCode.Space)) 
        {
            myRigidBoy.AddRelativeForce(moveUp * mainThrust * Time.deltaTime);
            if (!myAudioSource.isPlaying) {
                myAudioSource.Play();
            } 
        }
        else {
                myAudioSource.Stop();
            }
    }
    void processRotation() {
        myRigidBoy.freezeRotation = true;
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        myRigidBoy.freezeRotation = false;
    }
}
