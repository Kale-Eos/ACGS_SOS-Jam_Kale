using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoat : MonoBehaviour
{
    private float horizVel;
    public int laneNum = 2;
    public string controlLocked = "n";

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, -20);

        if(Input.GetKeyDown(KeyCode.A) && laneNum>1 && controlLocked == "n")
        {
            horizVel = -30;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }

        if (Input.GetKeyDown(KeyCode.D) && laneNum<3 && controlLocked == "n")
        {
            horizVel = 30;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}
