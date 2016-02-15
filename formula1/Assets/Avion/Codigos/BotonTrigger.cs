using UnityEngine;
using System.Collections;

public class BotonTrigger : MonoBehaviour {

	private Trampas[] script;
	// Use this for initialization
	void Start () {

		script = GetComponentsInChildren<Trampas>();
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			Activacion();
		}
	}
	void Activacion (){
		bool activar = true;

		foreach(Trampas auxScript in script){

			auxScript.activacion = activar;
		}
	}
}
