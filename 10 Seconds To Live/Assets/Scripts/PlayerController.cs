﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float jumpRaycastDistance = 1f;
    [SerializeField] Transform mainCamera;

    [Header("Time")]
    [SerializeField] float timeElapsed = 0f;
    [SerializeField] float maxTime = 10f;
    [SerializeField] Slider timeSlider;
 
    //References
    Rigidbody rb;
    LevelLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        loader = FindObjectOfType<LevelLoader>();

        timeSlider.maxValue = maxTime;

        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        timeSlider.value = maxTime - timeElapsed;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var camForward = mainCamera.forward;
        var camRight = mainCamera.right;

        camForward.y = 0;
        camForward.Normalize();
        camRight.y = 0;
        camRight.Normalize();

        var moveDirection = (camForward * v * moveSpeed) + (camRight * h * moveSpeed);

        transform.LookAt(transform.position);
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        Ray r = new Ray(transform.position, Vector3.down);
        Debug.DrawLine(r.origin, r.origin + (Vector3.down * jumpRaycastDistance));
        RaycastHit hit;

        if(Input.GetButtonDown("Jump") && Physics.Raycast(r, out hit, jumpRaycastDistance))
        {
            Jump();
        }

        if(timeElapsed >= maxTime)
        {
            loader.LoadGameOver();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
