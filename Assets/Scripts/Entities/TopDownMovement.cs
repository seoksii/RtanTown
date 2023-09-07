using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float maxVelocity = 5f;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }


    private float GetVelocityDelta()
    {
        return maxVelocity * (1f - Mathf.Pow(Unity.Mathematics.math.tanh(_rigidbody.velocity.magnitude - maxVelocity / 2), 2)) / 2;
    }

    private void ApplyMovement(Vector2 direction)
    {
        _rigidbody.velocity += direction * GetVelocityDelta();
    }
}
