using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraZoom : MonoBehaviour {

	public float zoomSpeed = 3;

	void Update () {

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && GetComponent<Camera> ().fieldOfView > 10) {
			GetComponent<Camera> ().fieldOfView -= zoomSpeed;
		} 
		else if (Input.GetAxis ("Mouse ScrollWheel") <0 && GetComponent<Camera> ().fieldOfView < 60) 
		{
			GetComponent<Camera> ().fieldOfView += zoomSpeed;
		}
	}
}
