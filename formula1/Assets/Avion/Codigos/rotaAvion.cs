using UnityEngine;
using System.Collections;

public class rotaAvion : MonoBehaviour {
	
	public float angle = 0.0f;
	public bool sobreVuelo = false;
	public float tanteo;
	public float tanteo2;
	public float LimiteAngle = 20.0f;

	void start(){
		/*
		tanteo = 100;
		tanteo2 = 60;
		*/
	}

	void FixedUpdate(){

		angle = transform.localEulerAngles.z;
		if(movAvion.contador == 1){

			if(movAvion.BloqueoUp){

				if ((angle >= 270 && angle <= 360) || (angle <= 30 && angle >= 0) || (angle >= -90 && angle <= 0) ) {
					
					transform.Rotate (Vector3.forward * Time.deltaTime * 100);
				}
			}else{

				if (movAvion.Activar == true) {
					//60
					if ((angle >= 270 && angle <= 360) || (angle <= LimiteAngle && angle >= 0) || (angle >= -90 && angle <= 0) ) {
						
						transform.Rotate (Vector3.forward * Time.deltaTime * tanteo);
					}
				} else {
					//290 - 330
					if (((angle >= 290 && angle <= 360) || (angle <= 90 && angle >= 0) || (angle >= -90 && angle <= 0))) {
						
						transform.Rotate (Vector3.forward * Time.deltaTime * tanteo2 * -1);
					}
					/*
				if((movAvion.contador == 0)){


				}
				*/
				}
			}
		}
	}
	
	// Update is called once per frame

	void Update () {

		if ( movAvion.Activar == true ) {
		// el condicional actu para que no se pase de 60
	 	// y pueda cuando este entre 270 y 360 darle espacio y poder subir
			if(movAvion.TCU > 0.2f){

				tanteo = 150;

				if(LimiteAngle <= 60.0f){

					LimiteAngle += Time.deltaTime * (LimiteAngle*2);
				}
			}else{

				movAvion.Velocidad = 30.0f;
				tanteo = 100;
				LimiteAngle = 10.0f;
			}

			if(movAvion.TCU >= 0.6f){

				sobreVuelo = true;
				tanteo2 = 45;
			}else{

				sobreVuelo = false;
			}

		
		} else if ( movAvion.Activar == false ){

			if(sobreVuelo == false){

				tanteo2 = 30;
			}
		}


	}
}