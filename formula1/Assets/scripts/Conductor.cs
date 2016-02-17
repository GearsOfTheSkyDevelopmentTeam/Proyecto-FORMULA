using UnityEngine;
using System.Collections;

public class Conductor : MonoBehaviour {

	public static bool ConductorSeleccion = false;

	public Renderer rend;
	public float limite;
	public Vector3 LocalDesplazamiento = new Vector3(0,0,0);
	
	void Start () {
		
		rend = GetComponent<Renderer>();
		rend.material.SetFloat("_Outline",0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(ControlCamara.Seleccion) rend.material.SetFloat ("_Outline", 0);
	}

	void OnMouseEnter() {
		
		if(!ControlCamara.Seleccion){
			
			rend.enabled = true;
			rend.material.SetFloat("_Outline",2f);
		}
	}

	void OnMouseExit() {
		
		if (!ControlCamara.Seleccion) {
			
			rend.enabled = false;
			rend.material.SetFloat ("_Outline", 0);
		}
	}


	void OnMouseDown() {

		Pantalla.ConductorPress ();
		ConductorSeleccion = true;
		ControlCamara.Seleccion = true;
		Pantalla.PressConductor = true;
		ControlCamara.escape = true;
		ControlCamara.desplazamiento = LocalDesplazamiento;
		ControlCamara.Target = this.gameObject;	
	}
}