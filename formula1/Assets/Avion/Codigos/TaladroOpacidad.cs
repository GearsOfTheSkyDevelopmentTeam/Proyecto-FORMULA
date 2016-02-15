using UnityEngine;
using System.Collections;

public class TaladroOpacidad : MonoBehaviour {
	public float limite = 0f, VeloAumento = 0f,VeloReduccion = 0f,contador = 0f;
	public bool returna = false,activar = false;
	public Color opacidad;
	public Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();
		opacidad.a = 0; 
		rend.material.color = opacidad;
	}
	
	// Update is called once per frame
	void Update () {
	
		opacidad = rend.material.color;
		if (RotacionAvionLOOKAT.bandRight) {
			activar = true;

		} else {

			returna = false;
			activar = false;
			contador = 0;
		}


		if(activar){

			if (!returna) {
				if(contador <= limite){

					opacidad.a += Time.deltaTime * VeloAumento;
					contador += 0.01f;
				}else{

					contador = 0;
					returna = true;
				}
			} 
			
			if (returna && (contador <= limite)) {
				
				opacidad.a -= VeloReduccion * Time.deltaTime;
			}
		}

		if(opacidad.a < 0){

			opacidad.a = 0;
		}
		rend.material.color = opacidad;

	}
}
