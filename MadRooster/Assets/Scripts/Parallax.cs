using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
   
    public Transform cameraTransform;
    public float parallaxFactor;
    private Vector3 previousCamPos;
    private Vector3 deltaCamPos;
    void Start()
    {
        previousCamPos = cameraTransform.position;
    }

    void Update()
    {
        deltaCamPos = cameraTransform.position - previousCamPos;
        Vector3 parallaxPos = new Vector3(transform.position.x + (deltaCamPos.x * parallaxFactor), transform.position.y);
        transform.position = parallaxPos;
        previousCamPos = cameraTransform.position;

    }
}
