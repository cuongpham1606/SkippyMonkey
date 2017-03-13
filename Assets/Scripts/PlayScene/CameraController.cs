using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    private void Update()
    {
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }

    public void ScreenShake()
    {
        StartCoroutine(AnimateScreenShake());
        
    }

    private IEnumerator AnimateScreenShake()
    {
        Vector3 originalPosition = transform.position;
        float time = 0;
        while (time < 0.15f)
        {
            transform.position = new Vector3(originalPosition.x + Random.Range(-3f, 3f), transform.position.y, transform.position.z);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
