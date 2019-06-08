using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject dolphin;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().position = new Vector3(0, 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
