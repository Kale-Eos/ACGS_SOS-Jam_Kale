﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTransform : MonoBehaviour
{
    public class ShakeEvent
    {
        float duration;
        float timeRemaining;

        ShakeEventData data;

        public ShakeEventData.Target target
        {
            get
            {
                return data.target;
            }

        }

        Vector3 noiseOffset;
        public Vector3 noise;

        public ShakeEvent(ShakeEventData data)
        {
            this.data = data;
            duration = data.duration;
            timeRemaining = duration;

            float rand = 32.0f;
            noiseOffset.x = Random.Range(0.0f, rand);
            noiseOffset.y = Random.Range(0.0f, rand);
            noiseOffset.z = Random.Range(0.0f, rand);
        }

        public void Update()
        {
            float deltaTime = Time.deltaTime;
            timeRemaining -= deltaTime;

            float noiseOffsetDelta = deltaTime * data.frequency;

            noiseOffset.x += noiseOffsetDelta;
            noiseOffset.y += noiseOffsetDelta;
            noiseOffset.z += noiseOffsetDelta;

            noise.x = Mathf.PerlinNoise(noiseOffset.x, 0.0f);
            noise.y = Mathf.PerlinNoise(noiseOffset.x, 1.0f);
            noise.z = Mathf.PerlinNoise(noiseOffset.x, 2.0f);

            noise -= Vector3.one * 0.5f;
            noise *= data.amplitude;

            float agePercent = 1.0f - (timeRemaining / duration);
            noise *= data.blendOverLifetime.Evaluate(agePercent);
        }

        public bool IsAlive()
        {
            return timeRemaining > 0.0f;
        }

    }

    List<ShakeEvent> shakeEvents = new List<ShakeEvent>();

    public void AddShakeEvent(ShakeEventData data)
    {
        shakeEvents.Add(new ShakeEvent(data));
    }

    public void AddShakeEvent(float amplitude, float frequency, float duration, AnimationCurve blendOverLifetime, ShakeEventData.Target target)
    {
        ShakeEventData data = ScriptableObject.CreateInstance<ShakeEventData>();
        data.Init(amplitude, frequency, duration, blendOverLifetime, target);

        AddShakeEvent(data);
    }

    void LateUpdate()
    {
        Vector3 positionOffset = Vector3.zero;
        Vector3 rotationOffset = Vector3.zero;

        for (int i = shakeEvents.Count - 1; i != -1; i--)
        {
            ShakeEvent se = shakeEvents[]; se.Update();

            if(se.target == ShakeEventData.Target.Position)
            {
                positionOffset += se.noise;
            }
            else
            {
                rotationOffset += se.noise;
            }
            if(!se.IsAlive())
            {
                shakeEvents.RemoveAt(i);
            }
        }

        transform.localPosition = positionOffset;
        transform.localEulerAngles = rotationOffset;

    }
}
