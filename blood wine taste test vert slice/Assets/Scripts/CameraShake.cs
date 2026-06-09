using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPos;

    // Start is called before the first frame update
    void Start()
    {
        _originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;

        while (elapsedTime < 0.2f)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * 0.4f;
            float yOffset = Random.Range(-0.5f, 0.5f) * 0.4f;

            transform.localPosition = new Vector3(xOffset, yOffset, transform.localPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}
