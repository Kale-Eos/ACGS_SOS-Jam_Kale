using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platformManager;
    private float canRecycle = -1;
    private float delay = 1f;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yield return new WaitForSeconds(1.5f);
            platformManager.RecyclePlatform(this.transform.parent.gameObject);
        }
    }

    //private void OnBecameInvisible()
    //{
    //    platformManager.RecyclePlatform(this.gameObject);
    //}
}
