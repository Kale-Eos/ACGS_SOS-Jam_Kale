using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Buoyancy buoyancy;
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _yvelocity = 0.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        buoyancy = GetComponent<Buoyancy>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * _speed;

        if(_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yvelocity = _jumpHeight;
            }
        }
        else
        {
            _yvelocity -= _gravity;
        }

        velocity.y = _yvelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
