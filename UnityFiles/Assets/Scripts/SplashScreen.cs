using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

	private void Start()
	{
		StartCoroutine("countdown");
	}

	private IEnumerator countdown() 
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel(1);
	}


}
