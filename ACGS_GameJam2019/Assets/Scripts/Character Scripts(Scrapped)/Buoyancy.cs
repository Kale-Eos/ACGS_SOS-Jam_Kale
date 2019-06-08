using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Buoyancy : MonoBehaviour
{
    private CharacterController _controller;

    public float waterLevel = 0.0f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    //[SerializeField]
    //private float _speed = 5.0f;
    //[SerializeField]
    //private float _jumpHeight = 10.0f;
    //[SerializeField]
    //private float _yvelocity = 0.0f;

    float forceFactor;
    Vector3 floatForce;

    //void Start()
    //{
    //    _controller = GetComponent<CharacterController>();
    //}

    //void Update()
    //{
    //    Vector3 direction = new Vector3(0, 0, 1);
    //    Vector3 velocity = direction * _speed;

    //    velocity.y = _yvelocity;
    //    _controller.Move(velocity * Time.deltaTime);
    //}

    void FixedUpdate()
    {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);

        if (_controller.isGrounded == true) //&& forceFactor > 0.0f)
        {
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        _yvelocity = _jumpHeight;
        //    }
        //}

        //else
        //{
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
    }
}
