using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour {
    
    [SerializeField]
    private InputActionReference move;

    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rigidbody;

    void Start() {
        if (!move) {
            throw new MissingFieldException("InputActionReference is required!");
        } 
        rigidbody = GetComponent<Rigidbody2D>();
        if (!rigidbody) {
            throw new MissingComponentException("RigidBody2D is required!");
        }
    }

    void FixedUpdate() {
        Vector2 direction = move.action.ReadValue<Vector2>();
        rigidbody.velocity = direction * movementSpeed;
    }

}
