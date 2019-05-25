using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoolVariable playerAlive;
    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;

    bool didFlap = false;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;

    public AudioSource playerAudioSource;
    public AudioClip playerFlap;
    public AudioClip playerCrash;
    public AudioClip playerLight;

    void Awake ()
    {
        playerAlive.value = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }
    }

    private void FixedUpdate()
    {
        if(playerAlive.value)
            MovePlayer();
    }

    private void MovePlayer()
    {
        velocity.x = forwardSpeed;
        velocity += gravity;
        if (didFlap)
        {
            playerAudioSource.PlayOneShot(playerFlap);
            didFlap = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.fixedDeltaTime;

        float angle = 0;
        if (velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -45, -velocity.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag != "Sky")
        {
            playerAudioSource.PlayOneShot(playerCrash);
            print("game over");
            playerAlive.value = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Light")
            playerAudioSource.PlayOneShot(playerLight);
    }
}
