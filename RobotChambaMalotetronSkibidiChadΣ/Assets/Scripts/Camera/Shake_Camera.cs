using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Camera : MonoBehaviour
{
    public void TriggerShake(float magnitude, float duration)
    {
        StartCoroutine(ShakeCamera(magnitude, duration));
    }

    // Rutina de temblor de cámara
    IEnumerator ShakeCamera(float magnitude, float duration)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(originalPosition.x + xOffset, originalPosition.y + yOffset, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition; // Restaurar la posición original de la cámara
    }
}
