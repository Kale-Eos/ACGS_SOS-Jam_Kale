using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnKey : MonoBehaviour
{
    public ShakeTransform st;
    public ShakeEventData data;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            st.AddShakeEvent(data);
        }
    }
}
