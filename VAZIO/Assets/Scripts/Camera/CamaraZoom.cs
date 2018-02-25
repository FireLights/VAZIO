using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraZoom : MonoBehaviour {

	public float zoomSpeed = 3;
	public float minFOV = 10;
	public float maxFOV = 80;

	void Update () {

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && GetComponent<Camera> ().fieldOfView > minFOV) {
			GetComponent<Camera> ().fieldOfView -= zoomSpeed;
		} 
		else if (Input.GetAxis ("Mouse ScrollWheel") <0 && GetComponent<Camera> ().fieldOfView < maxFOV) 
		{
			GetComponent<Camera> ().fieldOfView += zoomSpeed;
		}
	}
}
