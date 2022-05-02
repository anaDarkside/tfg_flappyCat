using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initializeCamera : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public float backgroundHeight;
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        camera.orthographicSize = backgroundPrefab.transform.localScale.y*backgroundHeight/2f;
    }
}
