using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnCollisionEnter : MonoBehaviour
{
    public float lifetime = 5.0f;

    [HideInInspector]
    public Rigidbody rigidbody;

    public List<ShakeEventData> birthShakeEvents;
    public List<ShakeEventData> deathShakeEvents;

    public GameObject spawnOnCollisionEnter;
    public GameObject spawnOnDestroy;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float impactMagnitude = collision.relativeVelocity.magnitude;

        for (int i = 0; i < birthShakeEvents.Count; i++)
        {
            ShakeEventData seData = birthShakeEvents[i];
            // Camera.main.GetComponentInParent<ShakeTransform>().AddShakeEvent(ShakeEvents[i]);
            Camera.main.GetComponentInParent<ShakeTransform>().AddShakeEvent(seData.amplitude * impactMagnitude, birthShakeEvents[i].frequency, birthShakeEvents[i].duration, birthShakeEvents[i].blendOverLifetime, birthShakeEvents[i].target);
        }

        GameObject go = Instantiate(spawnOnCollisionEnter, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

        AudioSource audioSource = go.GetComponentInChildren<AudioSource>();
        audioSource.volume = Mathf.Lerp(0.0f, 1.0f, impactMagnitude / 15.0f);
        audioSource.Play();
    }

    void OnDestroy()
    {
        for (int i = 0; i < deathShakeEvents.Count; i++)
        {
            ShakeEventData seData = deathShakeEvents[i];
            Camera.main.GetComponentInParent<ShakeTransform>().AddShakeEvent(deathShakeEvents[i]);
            // Camera.main.GetComponentInParent<ShakeTransform>().AddShakeEvent(seData.amplitude * impactMagnitude, birthShakeEvents[i].frequency, birthShakeEvents[i].duration, birthShakeEvents[i].blendOverLifetime, birthShakeEvents[i].target);

        }

        Instantiate(spawnOnDestroy, transform.position, Quaternion.identity);
    }
}
