using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour {

	public float smooth = 0.3F,veloRotaY=45;
	public static GameObject Target;
	public static Vector3 desplazamiento = new Vector3(0,0,0);
	public static Vector3 posicionInicio = new Vector3(0,0,0);
	private float yVelocity = 0.0F;
	public static bool Seleccion = false;

	public float distance = 10f, height = 1.3f, width,izq,dere, heightDamping = 4f;
	private float currentRotationAngle, currentHeight, currentWidth;
	public Quaternion currentRotation;
	private bool escape = false;

	[HideInInspector]
	public float MovHorizontal,MovVertical,OrbitDegrees = 30f,RotaY;

	void Start () {

		izq = (width/3) + width;
		dere = ((width/3) - width)*-1;
		Target = GameObject.Find ("Target");
	}
	

	void Update () {

		if(Target){

			MovHorizontal = Input.GetAxis("Horizontal");
			MovVertical = Input.GetAxis("Vertical");
			MovHorizontal = Mathf.Round(MovHorizontal);
			MovVertical = Mathf.Round(MovVertical);

			if(!Seleccion){
				posicionInicio = transform.position;

				if(MovHorizontal != 0){

					if(Mathf.Sign(MovHorizontal) == -1){

						transform.position = RotatePointAroundPivot(transform.position,Target.transform.position,Quaternion.Euler(0, OrbitDegrees * Time.deltaTime, 0));
					}else{

						transform.position = RotatePointAroundPivot(transform.position,Target.transform.position,Quaternion.Euler(0, -OrbitDegrees * Time.deltaTime, 0));
					}
				}

				if(MovVertical != 0){
					
					if(Mathf.Sign(MovVertical) == -1){

						transform.localPosition= new Vector3(transform.localPosition.x,Mathf.Lerp(transform.localPosition.y,0f,Time.deltaTime),transform.localPosition.z);
					}else{

						transform.localPosition= new Vector3(transform.localPosition.x,Mathf.Lerp(transform.localPosition.y,3f,Time.deltaTime),transform.localPosition.z);
					}
				}
			
				SmoothLook(Target.transform.position);
			}else{
				if(Seleccion){
					SeleccionTarget ( Target , desplazamiento );
				}
				if(Input.GetKey (KeyCode.Escape)){

					escape= true;
					Target = GameObject.Find("Target");
				}

			}
		}

	}
	
	void SmoothLook(Vector3 newDirection){
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection-transform.position), Time.deltaTime*veloRotaY);
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
		return angle * ( point - pivot) + pivot;
	}

	void SeleccionTarget ( GameObject target , Vector3 desplazamiento ) {

	    float movV, movH;
		bool move = true;

		movV = Input.GetAxis ("Vertical");
		movV = Mathf.Round (movV);
		movH = Input.GetAxis ("Horizontal");
		movH = Mathf.Round (movH);

		if(escape){

			StartCoroutine("PosicionInicial");
		}else{
			distance = -0.1f;
			currentRotationAngle = transform.eulerAngles.y;
			currentHeight = transform.position.y;
			
			if (Mathf.Sign (movV) == 1) {
				
				currentHeight = Mathf.Lerp (currentHeight, height + 0.5f, heightDamping * Time.deltaTime);    
			} 
			
			if(movV == 0){
				
				currentHeight = Mathf.Lerp (currentHeight, height, heightDamping * Time.deltaTime);
			}
			
			if(movH == 0){
				
				currentWidth = Mathf.Lerp (currentWidth, width, heightDamping * Time.deltaTime);
			}else{
				
				if (Mathf.Sign (movH) == -1) {
					
					currentWidth = Mathf.Lerp (currentWidth, izq, heightDamping * Time.deltaTime);    
				}
				
				if (Mathf.Sign (movH) == 1) {
					
					currentWidth = Mathf.Lerp (currentWidth, dere, heightDamping * Time.deltaTime);
				}
			}
			
			currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
			
			
			transform.position = target.transform.position;
			transform.position -= currentRotation * Vector3.forward * distance;    
			
			transform.position = new Vector3(transform.position.x, currentHeight,currentWidth) - desplazamiento;
			
			Vector3 targetToLook = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
			transform.LookAt(targetToLook);
		}
	}


	IEnumerator PosicionInicial(){

		while(Vector3.Distance(transform.position,posicionInicio) > 0.1f){

			transform.position = Vector3.Lerp (transform.position,posicionInicio, heightDamping * Time.deltaTime);
			transform.LookAt(Target.transform.position);
			yield return null;
		}

		Seleccion = false;
		escape = false;
	}

}
