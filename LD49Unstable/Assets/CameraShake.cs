using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private float shakeDuration = 0f;

	public float shakeAmount = 0.2f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	public static CameraShake instance;

	void Awake()
	{
		if(instance == null) {instance = this;}
	}

	void OnEnable()
	{
		originalPos = transform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			transform.localPosition = originalPos;
		}
	}

	public void AddShakeTime(float shakeTime)
    {
		shakeDuration += shakeTime;
    }
}