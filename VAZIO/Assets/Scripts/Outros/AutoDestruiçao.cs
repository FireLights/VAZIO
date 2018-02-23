using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruiçao : MonoBehaviour {

	public float timer = 2f;
	public bool explode = false;
	public GameObject explosion;

	void Update() {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			if (explosion) {
				Instantiate (explosion, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}
	}
}
