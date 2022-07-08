using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NickContrroller : MonoBehaviour
{
    [SerializeField][Range(1,5)] private float _speed;

    private Animator _animator;
    private Rigidbody2D _rigidbody2d;
    private float _horizontalInput;
    private float _verticalInput;

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = _rigidbody2d.position;
        position.x += _speed * _horizontalInput * Time.deltaTime;
        position.y += _speed * _verticalInput * Time.deltaTime;
        _animator.SetInteger("UpDown", _verticalInput < 0 ? -1 : (int)Math.Ceiling(_verticalInput));
        _animator.SetInteger("Side", _horizontalInput < 0 ? -1 : (int)Math.Ceiling(_horizontalInput));

        _rigidbody2d.MovePosition(position);
    }
}
