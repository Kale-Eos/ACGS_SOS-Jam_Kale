using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropletShaderControl : MonoBehaviour
{
    public float DropletSize = 1f;
    //public float DropletTime 1f;
    //public float DropletBlur = 0f;

    Renderer rend;
    public Slider mainSlider;

    void Update()
    {
        rend = GetComponent<Renderer>();
        // rend.material.shader = Shader.Find("Unlit/DropletsUI");
    }

    //public void UpdateObject()
    //{
    //    for (int i=0; i < rend.materials.Length; i++)
    //    {
    //        rend.materials[i].SetVector("_T", new Vector4(1, 1, 1, mainSlider.value));
    //    }
    //}

    public void AdjuustSize(float newDropletSize)
    {
        DropletSize = newDropletSize;
    }

    //public void AdjuustTime(float newDropletTime)
    //{
    //    DropletTime = newDropletTime;
    //}

    //public void AdjuustBlur(float newDropletBlur)
    //{
    //    DropletBlur = newDropletBlur;
    //}
}
