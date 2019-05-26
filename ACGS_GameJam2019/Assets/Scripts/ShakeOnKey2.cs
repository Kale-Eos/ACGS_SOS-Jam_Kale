using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnKey2 : MonoBehaviour
{
    public ShakeTransform st;
    public ShakeEventData data;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.GetComponentInParent<ShakeTransform>().AddShakeEvent(data);
        }
    }
}
