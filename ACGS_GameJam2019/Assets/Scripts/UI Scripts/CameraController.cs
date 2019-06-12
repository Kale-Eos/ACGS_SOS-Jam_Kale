using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator CamChangeTo1st;

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;

    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);

        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }

        if (CamMode == 1)
        {
            //yield return new WaitForSeconds(1.5f);
            //CamChangeTo1st.Play("CamChanger");
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }
}
