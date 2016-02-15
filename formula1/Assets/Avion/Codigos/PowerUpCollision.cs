using UnityEngine;
using System.Collections;

public class PowerUpCollision : MonoBehaviour {

	static public bool PCollision = false;
	public float TiempoPower = 3.0f; 
	private float Contador = 0.0f;


	void Update(){

		if(PCollision){

			Contador += Time.deltaTime;
		}
		if(Contador >= TiempoPower){
		
			Contador = 0.0f;
			PCollision = false;
		}

	}

	void OnTriggerEnter (Collider ColTrigger){

		if(ColTrigger.tag == "SuperVelo" ){

			PCollision = true;
			Destroy(ColTrigger.gameObject);
		}

		if(ColTrigger.name == "NivelTerminado"){

			MovObjetoPunto.NivelCompletado = true;
			movAvion.ActivarMov = false;
			Fade.NivelTerminado = true;
			movAvion.contador = 0;
		}
	}
}
