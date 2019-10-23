using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {
    
    public Transform target;
    public float distance;
    public GameObject gaze;
    // Update is called once per frame
    private void Awake()
    {
        gaze.GetComponent<Renderer>().enabled = false;
    }

    void Update () {

        distance = Vector3.Distance(gaze.transform.position, target.position);
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GazeRing")
        {
            gaze.GetComponent<Renderer>().enabled = true;
        }
    }
}
