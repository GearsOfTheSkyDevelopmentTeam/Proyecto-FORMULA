using UnityEngine;
using System.Collections;

public class AnimacionRuta : MonoBehaviour {

	public float velocidad;
	public bool Running = false, band = false;
	public GameObject nivel;
	LightSwitch codigo;
	// Use this for initialization
	void Start () {

		if(nivel){

			codigo = nivel.GetComponent<LightSwitch>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(nivel){
			if(!Running && !band && !codigo.BN){

				StartCoroutine(AnimacionUp());
			}
		}
	}

	IEnumerator AnimacionUp(){

		float posicionActual = transform.position.y;

		while((-2 - posicionActual ) >= -1){
			Debug.Log (-2 - posicionActual);
			Running = true;
			posicionActual = Mathf.Lerp(posicionActual,-2, velocidad * Time.deltaTime);
			transform.position = new Vector3(transform.position.x,posicionActual,transform.position.z);
			if((-2 - posicionActual ) < -1) break;
			yield return null;
		}

		band = true;
		Running = false;
	}
}

/*
IEnumerator corutinaUp(){
	
	float rota = 0f;
	
	while((360-rota) >= 20f){
		
		Running = true;
		rota = Mathf.Lerp(rota, 360, veloRota * Time.deltaTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,rota);
		if((360-rota) < 20f) break;
		yield return null;
	}
	Running = false;
	bandUp = false;
	transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
	
}
*/