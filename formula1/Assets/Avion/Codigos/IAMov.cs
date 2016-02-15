using UnityEngine;
using System.Collections;

public class IAMov : MonoBehaviour {
	
	public float Fuerza;
	public float FuerzaHorizontal;
	public float Limite;
	private float Limiteaux;
	private float Tiempo = 0.0f;
	private Rigidbody Myrb;
	public float LimiteVelocidad;
	private int band = 1;
	public int gravedad = 1;


	void Start () {

		Limiteaux = Limite * 2;
		FuerzaHorizontal *= -1;
		Tiempo = 0.0f;
		Myrb = GetComponent<Rigidbody>();
	}


	void Update () {

		Tiempo += 0.1f;

		if (Tiempo > Limite) {

			if(band == 1 ){
				gravedad = gravedad * -1;
				band = 0;
			}

			if(Tiempo >= Limiteaux){
				band = 1;
				Tiempo = 0.0f;
			}
		} 
	}

	void FixedUpdate() {

		if(Myrb.velocity.magnitude >= LimiteVelocidad){

			Myrb.velocity = Myrb.velocity.normalized * LimiteVelocidad;
		}

		Myrb.velocity = new Vector3 (FuerzaHorizontal, (Fuerza * gravedad), 0);
		/*
		Myrb.AddForce (transform.right * FuerzaHorizontal );

		Myrb.AddForce (transform.up * Fuerza * gravedad);
		*/

	}	
}
