using UnityEngine;
using System.Collections;

public class CambioColor : MonoBehaviour {

	public float Inicio;
	public float Final;
	public float Tiempo = 0.0f;
	public float auxTiempo = 0.0f;
	public float LimiteA = 1.0f;
	public float LimiteB = 1.0f;
	private float espera = 0.0f;
	static public int niveles = 2;
	static public bool ApagarLlamas = false;
	bool ActivarEspera = false;
	bool band = false;
	bool auxBand = true;
	Color color;

	public Renderer rend;
	
	void Start () {
		rend = GetComponent<Renderer>();
		color.a = 255;
		band = false;
		Tiempo = 0.0f;
		auxTiempo = 0.0f;
	}

	void Update () {

		if (Tiempo <= LimiteA && !band) {

			Tiempo += Time.deltaTime * 0.35f;
			color = rend.material.color;
			//Debug.Log(rend.material.color.a);
			if(color.a >= 0f){

				color.a -= Tiempo * 0.02f;;
			}
			//color.a = Mathf.Lerp (255f, 0f, Tiempo);
			rend.material.color = color;
		} else {

			band = true;
			if(auxBand){
				Tiempo = 0.0f;
				color.a = 0.0f;
				ApagarLlamas = true;
				auxBand = false;
			}
			Tiempo += Time.deltaTime;

			if(Tiempo >= LimiteB){

				auxTiempo += Time.deltaTime * 0.35f;
				color = rend.material.color;
				if(color.a <= 255.0f){

					color.a += auxTiempo * 0.02f;
				}
				//color.a = Mathf.Lerp (Inicio, Final, auxTiempo);
				rend.material.color = color;
			}else{

				ActivarEspera = true;
			}
		}

		if(ActivarEspera){
			
			espera += Time.deltaTime;
			Debug.Log(espera);
			if(espera >= 4){
				
				Application.LoadLevel (niveles);
			}	
		}
	}
	
}
