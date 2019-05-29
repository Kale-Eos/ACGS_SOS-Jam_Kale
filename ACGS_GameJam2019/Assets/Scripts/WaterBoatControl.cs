using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoatControl : MonoBehaviour
{
    // Visible Properties
    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    // Used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }

    void FixedUpdate()
    {
        // Default Direction
        var forceDirection = transform.forward;
        var steer = 0;

        // Steer Direction [-1, 0, 1]
        if (Input.GetKey(KeyCode.A))
        {
            steer = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            steer = -1;
        }

        // Rotational Force
        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);

        // Compute Vectors
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);

        // forward/backward power
        if(Input.GetKey(KeyCode.W))
        {
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        }
        if(Input.GetKey(KeyCode.S))
        {
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * -MaxSpeed, Power);
        }
    }
}
