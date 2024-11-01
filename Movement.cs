using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float carSpeed = 5.0f;
    [SerializeField] float rotateSpeed = 5f;

    float verticalInput;
    float horizontalInput;

    [SerializeField] ParticleSystem exhaustParticles;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    
    rb = GetComponent<Rigidbody2D>();

    float verticalInput = Input.GetAxis("Vertical");
    float horizontalInput = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        carParticles();
    }

    private void MovePlayer()
    {
        carControls();
    }

    private void carParticles()
    {
        if (verticalInput != 0) {
        exhaustParticles.Play();
        }
    }

    private void carControls()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movementDirection = new Vector2 (horizontalInput, verticalInput)    ;
        movementDirection.Normalize();
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        transform.Translate(movementDirection * carSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }

}
