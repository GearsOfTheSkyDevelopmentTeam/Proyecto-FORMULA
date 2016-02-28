using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlPresentacion : MonoBehaviour {
	[HideInInspector]
	public SpriteRenderer imagen;
	public Sprite[] imagenes; 
	public float velo = 2;
	private float alpha = 1;
	private int tamaño = 0, contador = 0;
	bool Running = false, up = false;
	bool cambio = false;
	// Use this for initialization
	void Start () {
		
		imagen = GetComponent<SpriteRenderer>();
		foreach(Sprite s in imagenes){

			if(s) tamaño += 1;
		}
	
		tamaño -= 1;
	}

	void Update(){

		if(Running){

			Desvanecer(velo);
		}
	}

	public void ClickDere () {
		if (contador < tamaño && !Running) {
			contador += 1;
			Running = true;
		}
	}

	public void ClickIzq () {
		if (contador > 0 && !Running) {
			contador -= 1;
			Running = true;
		}
	}

	void Desvanecer(float velo){


		if(Running){
			
			if (alpha > 0 && !up) {
				
				imagen.color = new Color (imagen.color.r, imagen.color.g, imagen.color.b, alpha);
				alpha -= Time.deltaTime * velo;
			} else if(alpha < 1) {

				if(!cambio){

					imagen.sprite = imagenes[contador];
					cambio = true;
				}
				up = true;
				alpha += Time.deltaTime * velo;
				imagen.color = new Color (imagen.color.r, imagen.color.g, imagen.color.b, alpha);
			}

			if(alpha >= 1 && up){

				cambio = false;
				up = false;
				Running = false;
			}
		}
	}

	public void Salir(){

		SceneManager.LoadScene("MainMenu");
	}
}