using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPos = _camera.transform.localPosition;

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            _camera.transform.localPosition = new Vector3(xOffset, yOffset, _camera.transform.localPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
