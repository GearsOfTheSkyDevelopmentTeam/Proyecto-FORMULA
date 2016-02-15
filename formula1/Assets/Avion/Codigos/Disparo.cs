using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {

	Rigidbody rb;
	public float VeloDisparo = 0.0f;
	public Transform disparo;

	void Start () {

		rb = GetComponent<Rigidbody>();
	}

	void Update () {
	
		if(Input.GetKeyDown (KeyCode.Space)){

			Instantiate(disparo, transform.position, transform.rotation);
		}
	}
}
