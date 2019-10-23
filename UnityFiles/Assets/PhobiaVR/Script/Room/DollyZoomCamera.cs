using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyZoomCamera : MonoBehaviour
{

    public Transform target;
    public Camera camera;
    public float currDistance;

    private float initHeightAtDist;
    private bool dzEnabled;

    float viewTarget = 120f;
    float decreaseView; 
    public float speed = 5f; 

    // Calculate the frustum height at a given distance from the camera.
    float FrustumHeightAtDistance(float distance)
    {
        return (2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    // Calculate the FOV needed to get a given frustum height at a given distance.
    float FOVForHeightAndDistance(float height, float distance)
    {
        return (2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg);
    }

    // Start the dolly zoom effect.
    void StartDZ()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        initHeightAtDist = FrustumHeightAtDistance(distance);
        dzEnabled = true;
    }

    // Turn dolly zoom off.
    void StopDZ()
    {
        dzEnabled = false;
    }

    void Start()
    {
        StartDZ();
    }

    void Update()
    {
        if (dzEnabled)
        {
            // Measure the new distance and readjust the FOV accordingly.
            currDistance = Vector3.Distance(transform.position, target.position);
            camera.fieldOfView = FOVForHeightAndDistance(initHeightAtDist, currDistance);
        }


        // Simple control to allow the camera to be moved in and out using the up/down arrows.
       
        if(currDistance > 10)
        {
            camera.fieldOfView = viewTarget;
        }
        else if (currDistance < 10)
        {
            viewTarget -= Time.deltaTime * speed;
            decreaseView = viewTarget;   
            camera.fieldOfView = decreaseView;
             
        }

        if(currDistance < 4)
        {
            viewTarget = 60;
        }
        else if(currDistance > 11){
            viewTarget = 120;
        }



        //transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 5f);
    }
}


