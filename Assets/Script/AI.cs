using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class AI : MonoBehaviour {

    public float moveSpeed = 2f;  // Speed of movement
    public float maxY = 5f;       // Maximum Y position
    public float minY = 0f;       // Minimum Y position    

    private float distanceTravelledLimit = 60f;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    private Vector2 prevPosition;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null) {
            throw new MissingComponentException("RigidBody2 is required for AI");
        }
        moveDirection = Vector2.up;
    }

    void FixedUpdate() {
        rigidBody.velocity = moveDirection * moveSpeed;

        float distanceTravelled = Vector2.Distance(prevPosition, rigidBody.position);
        if (distanceTravelled > distanceTravelledLimit) {

            int random = Random.Range(0, 2);
            if (random == 1) {
                moveDirection = Vector2.up;
            } else {
                moveDirection = Vector2.down;
            }
            prevPosition = rigidBody.position;
            distanceTravelledLimit = Random.Range(60f, 100f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        moveDirection = moveDirection == Vector2.up ? Vector2.down : Vector2.up;
    }

}
