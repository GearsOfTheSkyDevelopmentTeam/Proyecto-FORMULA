using UnityEngine;
using System.Collections;

public class Cartucho : MonoBehaviour {

	//public Rigidbody rb;
	//public float AumentoGravedad;
	//public float ContraVelo;
	//public float LimiteVelocidad;
	public float Tiempo;
	public float LimiteTiempo;
	/*
	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		rb.AddForce (new Vector3(0,-1,0) * AumentoGravedad );
		rb.AddForce (new Vector3(1,0,0) * ContraVelo);

		if(rb.velocity.magnitude >= LimiteVelocidad)
		{
			rb.velocity = GetComponent<Rigidbody>().velocity.normalized * LimiteVelocidad;
		}
	}
	*/
	void Update () {

		Tiempo += Time.deltaTime;

		if(Tiempo >= LimiteTiempo){

			Destroy(this.gameObject);
		}
	}
}
