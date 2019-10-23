using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour {

    public Rigidbody propeller;
    public float propellerSpeed = 2;

	// Use this for initialization
	void Start () {

        propeller = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        propeller.transform.Rotate(Time.deltaTime * propellerSpeed, 0, 0);
	}
}
