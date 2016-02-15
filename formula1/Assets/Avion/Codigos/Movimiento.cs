using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	static float bottomLimit = 3, topLimit = 40;
	public float rightLimit = 1, leftLimit = 80;
	private float my,mx,VarianteX,VarianteY,auxY,auxX;
	public GameObject avionRota, movHorizontal;
	public bool bandU = true,bandD = true, bandR = true;
	public float tiempoD = 0f,tiempoU = 0f,tiempoR = 0f,limite,velo;
	public int contadorU=0,contadorD=0,contadorR=0;
	public float CambioH=1, CambioV=1;
	public bool player = true, SuperVelocidad = false;
	static public bool TiempoEspera = true;
	public float LimiteVelocidad;
	public float vSpeed,hSpeed,ContinuoH;
	public float Tiempo = 0.0f;
	public Rigidbody rb;
	public bool prueba = true;
	private bool block = true;
	
	void Start () {

		my = 0.0f;
		mx = 0.0f;
		vSpeed = 25;
		ContinuoH = 20;
		hSpeed = 20;
		VarianteX = hSpeed;
		VarianteY = vSpeed + 8.0f;
		auxY = vSpeed;
		auxX = hSpeed;
		rb = GetComponent<Rigidbody>();
	}

	void Update () {

		if(Tiempo <= 4f){
			ContadorEspera (ref Tiempo,ref TiempoEspera, 3f);
		}
		if (player) {

			if(TiempoEspera){
			
				if (PowerUpCollision.PCollision) {

					if (hSpeed <= 40) {

						//aumento
						hSpeed += Time.deltaTime + 0.2f;
						ContinuoH += Time.deltaTime + 0.2f;


					}
				} else {
					if (hSpeed > 20) {

						SuperVelocidad = true;
						//disminuye
						hSpeed -= Time.deltaTime + 0.2f;
						ContinuoH -= Time.deltaTime + 0.2f;


					}else{

						ContinuoH = 20; //reinicio variable continuo
						SuperVelocidad = false;
					}

				}

			}

			if(Input.GetKeyDown (KeyCode.UpArrow)){
		
				contadorU += 1;
			}
			
			if(Input.GetKeyDown (KeyCode.DownArrow)){
				
				contadorD += 1;
			}

			if(Input.GetKeyDown (KeyCode.RightArrow)){
				
				contadorR += 1;
			}

			MovArriba();
			MovAbajo();	
			MovAdelante();
		} else {

			if (PowerUpCollision.PCollision) {
				
				if (ContinuoH <= 40) {

					ContinuoH += Time.deltaTime + 0.2f;
				}
			} else {
				if (ContinuoH > 20) {

					ContinuoH -= Time.deltaTime + 0.2f;
				}	
			}
		}
	}
	
	void FixedUpdate(){

		CambioH = Input.GetAxis("Horizontal");
		CambioV = Input.GetAxis("Vertical");

		if (player && TiempoEspera) {
	
			if(Input.GetKey (KeyCode.UpArrow) && !PowerUpCollision.PCollision && !SuperVelocidad){

				vSpeed = auxY;
			}

			if(Input.GetKey (KeyCode.DownArrow) && !PowerUpCollision.PCollision && !SuperVelocidad){

				vSpeed = VarianteY;
			}

			if(Input.GetKey (KeyCode.RightArrow) && !PowerUpCollision.PCollision && !SuperVelocidad){

				hSpeed = VarianteX;
			}

			if(Input.GetKey (KeyCode.LeftArrow) && !PowerUpCollision.PCollision && !SuperVelocidad){
			
				hSpeed = auxX;
			}
			my = CambioV * vSpeed;
			mx = CambioH * hSpeed;

			if(bandD && bandU){

				rb.velocity = new Vector3 (mx + ContinuoH, my, 0);
				transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit + movHorizontal.transform.position.x, rightLimit + movHorizontal.transform.position.x), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
			}
		  
		} else {
			
			rb.velocity = new Vector3(ContinuoH, 0, 0);
		}
	}

	//Tiempo el cual espera el jugador al incio de cada batalla
	public void ContadorEspera(ref float Tiempo,ref bool TiempoEspera, float limite){

		if(Tiempo <= limite){

			Tiempo += Time.deltaTime;
		}else{
		//	Debug.Log("verdad");
			if(block){
			
				TiempoEspera = true;
				prueba = false;
			}
		}
	}

	IEnumerator TiempoManiobraD(){//para abajo
		
		float posicion = 0f,posicionActualY=0f;
		bool DeteccionPosicion = false;
		
		if(!DeteccionPosicion){
			
			posicion = transform.position.y;
			posicionActualY = transform.position.y - 15;
			posicionActualY = Mathf.Clamp(posicionActualY, bottomLimit, topLimit);
			DeteccionPosicion = true;
		}
		
		while(Mathf.Abs(posicionActualY - posicion) >= 0.01f){
			
			TiempoEspera = false;
			posicion = Mathf.Lerp(posicion,posicionActualY, 25 * Time.deltaTime);
			transform.position = new Vector3(transform.position.x,posicion,transform.position.z);
			yield return null;
		}
		TiempoEspera = true;
		
	}

	IEnumerator TiempoManiobraU(){//para abajo
		
		float posicion = 0f,posicionActualY=0f;
		bool DeteccionPosicion = false;
		
		if(!DeteccionPosicion){

			posicion = transform.position.y;
			posicionActualY = transform.position.y + 15;
			posicionActualY = Mathf.Clamp(posicionActualY, bottomLimit, topLimit);
			DeteccionPosicion = true;
		}

		while(Mathf.Abs(posicionActualY - posicion) >= 0.01f){

			TiempoEspera = false;
			posicion = Mathf.Lerp(posicion,posicionActualY, 25 * Time.deltaTime);
			transform.position = new Vector3(transform.position.x,posicion,transform.position.z);
			yield return null;
		}
		TiempoEspera = true;
		
	}

	IEnumerator TiempoManiobraR(){//para adelante
		
		float posicion = 0f,posicionActualX=0f;
		bool DeteccionPosicion = false;
		
		if(!DeteccionPosicion){
			
			posicion = transform.position.x;
			posicionActualX = transform.position.x + 30;
			//posicionActualX = Mathf.Clamp(posicionActualX, bottomLimit, topLimit);
			DeteccionPosicion = true;
		}
		
		while(Mathf.Abs(posicionActualX - posicion) >= 0.01f){
			
			TiempoEspera = false;
			posicion = Mathf.Lerp(posicion,posicionActualX, 10 * Time.deltaTime);
			transform.position = new Vector3(posicion,transform.position.y,transform.position.z);
			yield return null;
		}

		if(avionRota){

			avionRota.layer = 12;
		}
		TiempoEspera = true;
		
	}
	
	void MovArriba(){
		
		if((contadorU == 2) && (tiempoU <= limite) && bandU){
			
			RotacionAvionLOOKAT.bandUp = true;
			StartCoroutine(TiempoManiobraU());
			bandU = false;
		}
		
		if(tiempoU > limite){
			
			bandU = true;
			contadorU = 0;
			tiempoU = 0f;
		}
		
		if(contadorU >= 1){
			
			tiempoU += 0.01f;
		}
	}
	
	void MovAbajo(){
		
		if((contadorD == 2) && (tiempoD <= limite) && bandD){
			
			RotacionAvionLOOKAT.bandDown = true;
			StartCoroutine(TiempoManiobraD());
			bandD = false;
		}
		
		if(tiempoD > limite){
			
			bandD = true;
			contadorD = 0;
			tiempoD = 0f;
		}
		
		if(contadorD >= 1){
			
			tiempoD += 0.01f;
		}
	}

	void MovAdelante(){
		
		if((contadorR == 2) && (tiempoR <= limite) && bandR && avionRota){
			
			RotacionAvionLOOKAT.bandRight = true;
			avionRota.layer = 8;
			StartCoroutine(TiempoManiobraR());
			bandR = false;
		}
		
		if(tiempoR > limite){
			
			bandR = true;
			contadorR = 0;
			tiempoR = 0f;
		}
		
		if(contadorR >= 1){
			
			tiempoR += 0.01f;
		}
	}
}
