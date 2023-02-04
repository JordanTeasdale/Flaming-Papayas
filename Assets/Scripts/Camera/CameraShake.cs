using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator ShakeCamera(float intensity, float duration)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float z = Random.Range(-1f, 1f) * intensity;

            //transform.localPosition = new Vector3(x-23.98f, y - 2.41f, originalPos.z);
            transform.rotation = Quaternion.Euler(0, 0, z);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
