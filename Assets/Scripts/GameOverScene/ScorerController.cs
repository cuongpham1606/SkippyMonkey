using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ScorerController : MonoBehaviour {
    private Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayScene.Instance.Score();
        PlatformFactory.Instance.PutNewPlatformInPlace();

        
        coll.enabled = false;
    }
}
