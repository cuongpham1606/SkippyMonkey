using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
    public Collider2D scorerCollider;
    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        scorerCollider.enabled = true;
    }

    private void Update()
    {
        if (transform.position.y < mainCam.transform.position.y - mainCam.orthographicSize - 300) //tính theo unit của unity (liên quan đến Reference Per Unit)
        {
            gameObject.SetActive(false);
        }
    }
}
