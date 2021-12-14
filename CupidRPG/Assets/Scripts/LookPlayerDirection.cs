using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayerDirection : MonoBehaviour
{
    GameObject cam;
    private void Awake()
    {
        cam = FindObjectOfType<Camera>().gameObject;
    }
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
