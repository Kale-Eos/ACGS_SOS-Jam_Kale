using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreM : MonoBehaviour
{
    public static int orbTotal = 0;
    public static float timeTotal = 0;
}

public class ScoreManager : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(gameObject.name == "RainOrbScore")
        {
           // GetComponent<TextMesh>().text = 
        }

        if (gameObject.name == "TimeLastedScore")
        {
           // GetComponent<TextMesh>().text =
        }

    }
}
