using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pantalla : MonoBehaviour {
//	
//	public GameObject AuxButton,AuxButtomZoom,AuxImage;
//	public static bool PressZoom = false,PressConductor = false;
//	
//	public static Vector3 AuxLocalDesplazamiento = new Vector3(0,0,0);
//	public static GameObject AuxTargetZoom;
//	public static GameObject ExitPantalla, ZoomPantalla,MenuPantalla;
//
//	void Start () {
//
//		MenuPantalla = AuxImage;
//		ExitPantalla = AuxButton;
//		ZoomPantalla = AuxButtomZoom;
//		AllFalse ();
//	}
//
//	public static void PantallaPress(){
//		AllTrue ();
//	}
//
//	public static void ConductorPress(){
//		UIController.showInfoPanel = true;
//
//		ExitPantalla.SetActive(true);
//		ButtomFalse(MenuPantalla);
//		ButtomFalse(ZoomPantalla);
//	}
//
//	public void ExitPress(){
//
//		if (!PressConductor) {
//			if (PressZoom) {
//				ControlCamara.escape = true;
//				ControlCamara.Target = GameObject.Find("Target");
//				PressZoom = false;
//				AllTrue ();
//
//			}else{
//				
//				ControlCamara.Seleccion = true;
//				ControlCamara.desplazamiento = ControlCamara.posicionInicio;
//				AllFalse ();
//			}
//		} else {
//
//			ControlCamara.desplazamiento = ControlCamara.posicionInicio;
//			ControlCamara.Seleccion = true;
//			ControlCamara.escape = true;
//			ControlCamara.Target = GameObject.Find ("Target");
//			ButtomFalse(ExitPantalla);
//			PressConductor = false;
//		}
//	}
//
//	public void Zoom(){
//		UIController.DeactivateUI();
//		UIController.showInfoPanel = false;
//
//		PressZoom = true;
//		MenuPantalla.SetActive(false);
//		ButtomFalse(ZoomPantalla);
//		ControlCamara.desplazamiento = AuxLocalDesplazamiento;
//		ControlCamara.Seleccion = true;
//		ControlCamara.Target = AuxTargetZoom;	
//	}
//
//	public static void AllFalse(){
//		UIController.DeactivateUI();
//		UIController.showInfoPanel = true;
//
//		MenuPantalla.SetActive(false);
//		ExitPantalla.SetActive(false);
//		ZoomPantalla.SetActive(false);
//	}
//
//	public static void AllTrue(){
//		UIController.ActivateUI();
//		UIController.showInfoPanel = false;
//
//		MenuPantalla.SetActive(true);
//		ExitPantalla.SetActive(true);
//		ZoomPantalla.SetActive(true);
//	}
//
//	public static void ButtomFalse(GameObject boton){
//		
//		boton.SetActive(false);
//	}
}
