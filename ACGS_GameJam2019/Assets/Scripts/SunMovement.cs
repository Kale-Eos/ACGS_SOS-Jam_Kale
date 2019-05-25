using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    #region Variables
    public Transform sunTransform;
    public float speedVariable;
    #endregion

    #region Functions

    void FixedUpdate()
    {
        sunTransform.Rotate(Vector3.down, speedVariable);
        sunTransform.Rotate(Vector3.left, speedVariable);
    }

    #endregion
}
