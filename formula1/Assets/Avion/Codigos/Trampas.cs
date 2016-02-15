using UnityEngine;
using System.Collections;

public class Trampas : MonoBehaviour {

	public int tipo = 0,SentidoRota = 1;
	public bool activacion = false;
	public float Tiempo=0,VeloMov=10,Limite=1;
	

	// Update is called once per frame
	void Update () {
		if(activacion){
			switch(tipo){

			case 0:

				Puerta(Limite,ref Tiempo,ref VeloMov);
			break;

			case 1:

				RotarTuercas(Limite,ref Tiempo,ref VeloMov,SentidoRota);
			break;

			}
		}
	}

	void Puerta(float Limite,ref float Tiempo,ref float VeloMov){

		if(Tiempo <= Limite){
			Tiempo += 0.01f;
			transform.position += Vector3.up * VeloMov ;
		}

	}

	void RotarTuercas(float Limite, ref float Tiempo, ref float VeloMov, int SentidoRota){

		if(Tiempo<=Limite){
			Tiempo += 0.01f;
			transform.Rotate(Vector3.forward * VeloMov *SentidoRota);
		}
	}
}
