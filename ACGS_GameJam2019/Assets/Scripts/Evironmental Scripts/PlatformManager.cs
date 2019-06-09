using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformprefabs;
    [SerializeField]
    private int ZedOffset;

    void Start()
    {
        for(int i = 0; i < platformprefabs.Length; i++)
        {
            Instantiate(platformprefabs[i], new Vector3(0, -1, i * 160), Quaternion.Euler(0, 0, 0));
            ZedOffset += 160;
        }
    }

    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, ZedOffset);
        ZedOffset += 160;
    }
}
