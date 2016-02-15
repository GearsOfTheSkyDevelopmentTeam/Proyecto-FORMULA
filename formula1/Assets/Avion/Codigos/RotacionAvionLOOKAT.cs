using UnityEngine;
using System.Collections;

public class RotacionAvionLOOKAT : MonoBehaviour {

	private bool Running = false;
	public bool jugador = false;
	public Transform target;
	static public bool bandUp = false, bandDown = false,bandRight = false;
	public float veloRota , distance = 10f, height = 1.3f, Tiempo = 0f, heightDamping = 4f,Rotacion = 0f;
	private float wantedHeight, currentRotationAngle, currentHeight;
	public Vector3 dir;
	public Quaternion currentRotation;
	

	void FixedUpdate () {
		
		if(Tiempo <= 3.0f){

			Tiempo += Time.deltaTime;
			heightDamping = 1.5f;
		}else{
			
			heightDamping = 4.0f;
		}
		
		wantedHeight = target.position.y + height;
		
		currentRotationAngle = transform.eulerAngles.y;
		currentHeight = transform.position.y;
		
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);    
		currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		
		
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;    

		transform.position = new Vector3(transform.position.x, currentHeight,transform.position.z);

		Vector3 targetToLook = new Vector3(target.position.x, target.position.y, transform.position.z);
		transform.LookAt(targetToLook);
	}

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

	IEnumerator corutinaDown(){
		
		float rota = 0f;

		while((360-rota) >= 20f){
		
			Running = true;
			rota = Mathf.Lerp(rota, 360, veloRota * Time.deltaTime);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,-rota);
			if((360-rota) < 20f) break;
			yield return null;
		}

		Running = false;
		bandDown = false;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
	
	}

	IEnumerator corutinaRight(){
		
		float rota = 0f;
		
		while((360-rota) >= 20f){
			
			Running = true;
			rota = Mathf.Lerp(rota, 360, veloRota * Time.deltaTime);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,rota);
			if((360-rota) < 20f) break;
			yield return null;
		}
		
		Running = false;
		bandRight = false;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
		
	}

	void Update(){

		if(bandUp && !Running && jugador){

			StartCoroutine(corutinaUp());
		}

		if(bandDown && !Running && jugador){

			StartCoroutine(corutinaDown());
		}

		if(bandRight && !Running && jugador){
			
			StartCoroutine(corutinaRight());
		}
	}
}
