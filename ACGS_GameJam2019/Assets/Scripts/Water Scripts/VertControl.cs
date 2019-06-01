using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertControl : MonoBehaviour
{
    public float displacementAmount;
    //public ParticleSystem explosionParticles;
    MeshRenderer meshRender;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        displacementAmount = Mathf.Lerp(displacementAmount, 0, Time.deltaTime);
        meshRender.material.SetFloat("_Amount", displacementAmount);

        if(Input.GetButtonDown("Jump"))
        {
            displacementAmount += 1f;
            //explosionParticles.Play();
        }
    }
}
