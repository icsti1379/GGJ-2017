﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class Movement : MonoBehaviour
{

    private bool Freeze = false;
    private Vector3 moveVector;
    private Vector3 rotateVector;
    [SerializeField]
    private float speed = 0;
    Rigidbody physics;
    GamePadState gamePad;

    [SerializeField]
    private float maxSpeed = 1;


    Vector3 spawnIsle1 = new Vector3(-1.21f, 0.572f, -6.53f);
    Vector3 spawnIsle2 = new Vector3(-16.2f, 0.597f, -27.3f);
    Vector3 spawnIsle3 = new Vector3(-34.202f, 2.28f, -44.159f);
    Vector3 spawnIsle4 = new Vector3(-61.2f, -8.11f, -46.72f);
    Vector3 spawnIsle5 = new Vector3(-95.57f, -8.11f, -52.21f);


    // Use this for initialization
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        maxSpeed = maxSpeed / 5;
    }

    // Update is called once per frame
    void Update()
    {
        gamePad = GamePad.GetState(PlayerIndex.One);
        Vector2 leftStick = new Vector2(gamePad.ThumbSticks.Left.X, gamePad.ThumbSticks.Left.Y);
        Vector2 rightStick = new Vector2(gamePad.ThumbSticks.Right.X, gamePad.ThumbSticks.Right.Y);
        TryMove(leftStick);
        TryRotate(rightStick);
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(1, 0, 0) * moveVector.y);
        transform.Translate(new Vector3(0, 0, -moveVector.x));
        FixSpeed();
        moveVector = Vector3.zero;

        transform.Rotate(rotateVector);


        if(Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenuScreen");
        }
    }

    private void FixSpeed()
    {
        if (physics.velocity.magnitude > maxSpeed)
        {
            physics.velocity = physics.velocity.normalized * maxSpeed;
        }
    }

    private void TryMove(Vector2 leftStick)
    {
        if (!Freeze)
        {
            moveVector = new Vector3(leftStick.x * Time.deltaTime * speed, leftStick.y * Time.deltaTime * speed);
        }
    }

    private void TryRotate(Vector2 rightStick)
    {
        if (!Freeze)
        {
            rotateVector = new Vector3(0, rightStick.x, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collider_Isle1"))
        {
            transform.position = spawnIsle1;
        }
        else if(other.gameObject.CompareTag("Collider_Isle2"))
        {
            transform.position = spawnIsle2;
        }
        else if (other.gameObject.CompareTag("Collider_Isle3"))
        {
            transform.position = spawnIsle3;
        }
        else if (other.gameObject.CompareTag("Collider_Isle4"))
        {
            transform.position = spawnIsle4;
        }
        else if (other.gameObject.CompareTag("Collider_Isle5"))
        {
            transform.position = spawnIsle5;
        }
    }
}
