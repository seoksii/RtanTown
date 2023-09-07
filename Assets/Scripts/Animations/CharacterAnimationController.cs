using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private TopDownCharacterController _controller;
    private Rigidbody2D _rigidbody2d;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _controller = GetComponentInParent<TopDownCharacterController>();
        _rigidbody2d = GetComponentInParent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += SetFlipX;
    }


    void Update()
    {
        SetAnimationVelocity();
    }

    private void SetFlipX(Vector2 direction)
    {
        if (direction.x != 0) _spriteRenderer.flipX = direction.x < 0;
    }

    private void SetAnimationVelocity()
    {
        _animator.SetFloat("Velocity", _rigidbody2d.velocity.magnitude);
    }
}
