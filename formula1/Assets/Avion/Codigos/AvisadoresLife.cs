using UnityEngine;
using System.Collections;

public class AvisadoresLife : MonoBehaviour {

	public float Tiempo = 0.0f, modificador = 0.0f;
	public int contador = 0;
	public bool Aparecer = false;
	public Transform Kamikaze;
	public bool band = false,aux = false;

	// Update is called once per frame
	void Update () {

		transform.localScale = new Vector3 (modificador, modificador, modificador);

		if(Aparecer){//AQUI!!

			if ((transform.localScale.y <= 0.11) && !band) {

				aux = false;
				modificador += Tiempo * Time.deltaTime;
			} else {

				modificador -= Tiempo * Time.deltaTime;

				if(transform.localScale.y <= 0.01f && !aux){

					contador += 1;
					band = false;
					aux = true;
				}else{

					band = true;
				}
			}
		}

		if(contador >= 2){

			Aparecer = false;//AQUI!!
			contador = 0;
			modificador = 0;
			Instantiate(Kamikaze,transform.position,transform.rotation);
		}
	}
}