using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pantalla : MonoBehaviour {
	
	public GameObject AuxButton,AuxButtomZoom,AuxImage;

	public static bool PressZoom = false;
	
	public static Vector3 AuxLocalDesplazamiento = new Vector3(0,0,0);
	public static GameObject AuxTargetZoom;
	public static GameObject ExitPantalla, ZoomPantalla,MenuPantalla;

	void Start () {

		MenuPantalla = AuxImage;
		ExitPantalla = AuxButton;
		ZoomPantalla = AuxButtomZoom;

		AllFalse ();

	}

	public static void PantallaPress(){

		AllTrue ();
	}

	public void ExitPress(){

		if (PressZoom) {

			ControlCamara.escape = true;
			ControlCamara.Target = GameObject.Find ("Target");
			PressZoom = false;
			AllTrue ();
		} else {

			AllFalse ();
		}
	}

	public void Zoom(){

		PressZoom = true;
		MenuPantalla.SetActive(false);
		ButtomFalse( ZoomPantalla );

		ControlCamara.desplazamiento = AuxLocalDesplazamiento;
		ControlCamara.Seleccion = true;
		ControlCamara.Target = AuxTargetZoom;	
	}

	public static void AllFalse(){

		MenuPantalla.SetActive(false);
		ExitPantalla.SetActive(false);
		ZoomPantalla.SetActive(false);
	}

	public static void AllTrue(){

		MenuPantalla.SetActive(true);
		ExitPantalla.SetActive(true);
		ZoomPantalla.SetActive(true);
	}

	void ButtomFalse( GameObject boton){

		boton.SetActive(false);
	}
}