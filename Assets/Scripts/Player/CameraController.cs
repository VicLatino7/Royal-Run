using System;
using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ParticleSystem speedupParticleSystem;
    [Header("FOV Settings")]
    [SerializeField] float minFOV = 60f;
    [SerializeField] float maxFOV = 90f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;
    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {   
        StopAllCoroutines(); // Stop any ongoing FOV change coroutines
        StartCoroutine(ChangeFOVRoutine(speedAmount));

        if (speedAmount > 0)
        {
            speedupParticleSystem.Play();
        }
        else
        {
            speedupParticleSystem.Stop();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifier, minFOV, maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
