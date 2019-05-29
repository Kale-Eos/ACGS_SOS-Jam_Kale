using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFloat : MonoBehaviour
{
    // Public properties
    public float AirDrag = 1;
    public float WaterDrag = 10;
    public Transform[] FloatPoint;
    public bool AttachToSurface;

    // Used components
    protected Rigidbody Rigidbody;
    protected WaveControl Waves;

    // Water Line
    protected float WaterLine;
    protected Vector3[] WaterLinePoints;

    // Help vectors
    protected Vector3 CenterOffset;
    protected Vector3 SmoothVectorRotation;
    protected Vector3 TargetUp;
    public Vector3 Center
    {
        get
        {
            return transform.position + CenterOffset;
        }
    }

    void Awake()
    {
        Waves = FindObjectOfType<WaveControl>();
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.useGravity = false;

        // Compute center
        WaterLinePoints = new Vector3[FloatPoint.Length];
        for (int i = 0; i < FloatPoint.Length; i++)
        {
            WaterLinePoints[i] = FloatPoint[i].position;
            CenterOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;
        }
    }

    void Update()
    {
        // default water surface
        var newWaterLine = 0f;
        var pointUnderWater = false;

        // set WaterLinePoint and WaterLine
        for (int i = 0; i < FloatPoint.Length; i++)
        {
            // height
            WaterLinePoints[i] = FloatPoint[i].position;
            WaterLinePoints[i].y = Waves.GetHeight(FloatPoint[i].position);
            newWaterLine += WaterLinePoints[i].y / FloatPoint.Length;
            if (WaterLinePoints[i].y > FloatPoint[i].position.y)
            {
                pointUnderWater = true;
            }
        }

        var waterLineDelta = newWaterLine - WaterLine;
        WaterLine = newWaterLine;

        // gravity
        var gravity = Physics.gravity;
        Rigidbody.drag = AirDrag;
        if (WaterLine > Center.y)
        {
            Rigidbody.drag = WaterDrag;

            // under water
            if (AttachToSurface)
            {
                // attach to water surface
                Rigidbody.position = new Vector3(Rigidbody.position.x, WaterLine - CenterOffset.y, Rigidbody.position.z);
            }
            else
            {
                // go up
                gravity = -Physics.gravity;
                transform.Translate(Vector3.up * waterLineDelta * 0.9f);
            }
        }

        Rigidbody.AddForce(gravity * Mathf.Clamp(Mathf.Abs(WaterLine - Center.y), 0, 1));

        // Compute up vector
        TargetUp = PhysicsHelper.GetNormal(WaterLinePoints);

        // rotation
        if (pointUnderWater)
        {
            // Attach to water surface
            TargetUp = Vector3.SmoothDamp(transform.up, TargetUp, ref SmoothVectorRotation, 0.2f);
            Rigidbody.rotation = Quaternion.FromToRotation(transform.up, TargetUp) * Rigidbody.rotation;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (FloatPoint == null)
        {
            return;
        }

        for (int i = 0; i < FloatPoint.Length; i++)
        {
            if (FloatPoint[i] == null)
            {
                continue;
            }

            if (Waves != null)
            {
                // draw cube
                Gizmos.color = Color.red;
                Gizmos.DrawCube(WaterLinePoints[i], Vector3.one * 0.3f);
            }

            // draw sphere
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(FloatPoint[i].position, 0.1f);
        }

        // draw center
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(Center.x, WaterLine, Center.z), Vector3.one * 1f);
        }
    }
}