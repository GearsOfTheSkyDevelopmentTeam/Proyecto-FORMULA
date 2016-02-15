using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static public int puntaje = 0;
	public float largo = 20;
	public float ancho = 83 , TiemporReinicio = 0f;
	public int centroX = 200, centroY = 100, nivelActual;
	public float x = 4.3f;
	public float y = 3f;
	
	void OnGUI() {

		GUI.color = Color.white;
		GUI.Box (new Rect (x, y, ancho, largo), "Score = " + puntaje.ToString ("0"));

		if(!movAvion.ActivarMov && !Fade.NivelTerminado){

			GUI.Box (new Rect ((Screen.width-centroX)/2, (Screen.height-centroY)/2, 140, 24), "Salir(esc) Reinicio(r)");


		}

		if(Input.GetKeyDown (KeyCode.Escape)){
			
			movAvion.ActivarMov = true;
			Score.puntaje = 0;
			SalirJuego();
		}
		
		if(!movAvion.ActivarMov){
			
			TiemporReinicio += Time.deltaTime;
			
			if((TiemporReinicio >= 1.0f)){
				
				if(Input.GetKeyDown (KeyCode.R) && (!movAvion.ActivarMov)){
					TiemporReinicio = 0.0f;
					movAvion.ActivarMov = true;
					Score.puntaje = 0;
					reinicio(nivelActual);
				}
			}
		}
	}

	void SalirJuego(){
		
		CambioColor.niveles = 1;
		Application.LoadLevel (1);
	}

	void reinicio(int nivelActual){
		
		Application.LoadLevel (nivelActual);
	}
}
