using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour {

	public const int NoRestringido = 1;
	public const int Restringido = 2;
	public int modo;

	public GameObject target;
	public float smooth = 0.3F,veloRotaY=100;
	public static Vector3 desplazamiento = new Vector3(0,0,0);
	public static Vector3 posicionInicio = new Vector3(0,0,0);
	public static bool Seleccion = false;

	public float distance = 10f, width,izq,dere;
	public Quaternion currentRotation;
	public static bool escape = false;

	Vector3 posicionVieja;
	public bool clickBlockeado {get; private set;}
	bool corriendoCorutina = false;

	Restricciones restricciones;
	static Restricciones movLibre = new Restricciones(Mathf.Infinity);

	[HideInInspector]
	float OrbitDegrees = 40f, RotaY;

	private static ControlCamara _instance;

	private ControlCamara() {}

	void Start(){
		clickBlockeado = false;
		izq = (width/3) + width;
		dere = ((width/3) - width)*-1;
		target = GameObject.Find("MainTarget");
		posicionInicio = transform.position;
		posicionVieja = posicionInicio;
		modo = NoRestringido;
	}

	void Update(){
		if(target){
			Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if(!corriendoCorutina){
				Mover(input, modo == NoRestringido ? movLibre : restricciones);
			}
			SmoothLook(target.transform.position);
		}
	}

	void LateUpdate(){
		if(target){
			
		}
	}

	public void Reset(){
		target = GameObject.Find("MainTarget");
		modo = NoRestringido;
		StopCoroutine("MoverHacia");
		StartCoroutine("MoverHacia", posicionVieja);
		clickBlockeado = false;
	}

	public void BlockearCLick(){
		clickBlockeado = true;
//		posicionVieja = transform.position;
	}

	public void DesbloquearClick(){
		clickBlockeado = false;
	}

	public void Mover(Vector2 input, Restricciones restricciones){
		Vector3 newPosition = transform.position;

		if(input.x != 0){
			float dirX = -Mathf.Sign(input.x);				
			float rot = dirX * OrbitDegrees * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler(0, rot, 0);
			newPosition = RotatePointAroundPivot(newPosition, target.transform.position, rotation);
		}

		if(input.y != 0){
			float distanciaY = Mathf.Sign(input.y) < 0 ? 1f : 3f;
			Vector3 lerpTo = new Vector3(newPosition.x, distanciaY, newPosition.z);
			newPosition = Vector3.Lerp(newPosition, lerpTo, Time.deltaTime);
		}
			
		newPosition.x = Mathf.Clamp(newPosition.x, restricciones.minX, restricciones.maxX);
		newPosition.y = Mathf.Clamp(newPosition.y, restricciones.minY, restricciones.maxY);
		newPosition.z = Mathf.Clamp(newPosition.z, restricciones.minZ, restricciones.maxZ);

		transform.position = newPosition;
	}

	public void CambiarTarget(GameObject _target, int _modo, Vector3 newPosition, bool doOverride = false){
		float valX = .5f;
		if(!clickBlockeado || doOverride){
			clickBlockeado = true;
			posicionVieja = transform.position;
			target = _target;
			modo = _modo;

			restricciones.minX = newPosition.x - valX;
			restricciones.maxX = newPosition.x + valX;

			restricciones.minZ = newPosition.z - valX;
			restricciones.maxZ = newPosition.z + valX;

			restricciones.minY = newPosition.y - .3f;
			restricciones.maxY = newPosition.y + .5f;

			StopCoroutine("MoverHacia");
			StartCoroutine("MoverHacia", newPosition);
		}
	}

	public void CambiarTarget(ParteCarro _parteCarro, bool doOverride = false){
		CambiarTarget(_parteCarro.gameObject, _parteCarro.ModoCamara, _parteCarro.DesplazamientoLocal, doOverride);
	}

	IEnumerator MoverHacia( Vector3 posicion){
		corriendoCorutina = true;
		while(Vector3.Distance(transform.position, posicion) > .05f){
			transform.position = Vector3.Lerp(transform.position,posicion, .05f);
			yield return null;
		}
		corriendoCorutina = false;
	}
		
	void SmoothLook(Vector3 newDirection){
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime*veloRotaY);
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
		return angle * ( point - pivot) + pivot;
	}

	//Singleton
	public static ControlCamara instance{
		get{
			if(_instance == null){
				_instance = (ControlCamara) FindObjectOfType(typeof(ControlCamara));
			}
			if(_instance == null){
				_instance = new ControlCamara();
			}
			return _instance;
		}
	}
	
	public static float ClampAngle(float angle, float min, float max){
		if(angle < -360){
			angle += 360;
		}
		if(angle > 360){
			angle -= 360;
		}
		return Mathf.Clamp(angle, min, max);
	}

	//Struct para guardar informacion de las restricciones
	public struct Restricciones{
		public float minX, maxX;
		public float minY, maxY;
		public float minZ, maxZ;

		public Restricciones(float val){
			minX = minY = minZ = -val;
			maxX = maxY = maxZ = val;
		}

		public void Cambiar(float _minX, float _maxX, float _minY, float _maxY, float _minZ, float _maxZ){
			minX = _minX;
			maxX = _maxX;
			minY = _minY;
			maxY = _maxY;
			minZ = _minZ;
			maxZ = _maxZ;
		}
	}

	public void MoverSinRestricciones(Vector2 input){
		if(input.x != 0){
			float dirX = -Mathf.Sign(input.x);
			Quaternion rotation = Quaternion.Euler(0, dirX * OrbitDegrees * Time.deltaTime, 0);
			transform.position = RotatePointAroundPivot(transform.position, target.transform.position, rotation);
		}
		if(input.y != 0){
			float distanciaY = Mathf.Sign(input.y) < 0 ? 0f : 3f;
			Vector3 lerpTo = new Vector3(transform.position.x, distanciaY, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, lerpTo, Time.deltaTime);
		}
	}
}
