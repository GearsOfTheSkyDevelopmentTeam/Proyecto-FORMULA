using UnityEngine;
using System.Collections;

public class MovDisparo : MonoBehaviour {
	
	Rigidbody rb;
	public float VeloDisparo = 0.0f;
	public Transform disparo;
	float contador = 0.0f;
	
	void Start () {
		
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		
		rb.AddForce (transform.up * VeloDisparo *-1);

	}

	void Update () {
			
		contador += Time.deltaTime;
		
		if(contador >= 0.4f){

			Destroy (this.gameObject);
		}
	}
}
