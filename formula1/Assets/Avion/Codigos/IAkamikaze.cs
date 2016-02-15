using UnityEngine;
using System.Collections;

public class IAkamikaze : MonoBehaviour {

	public Rigidbody rb;
	public float damping = 5.0f, Tiempo;
	public Transform MyTransform;
	public GameObject Seguidor,padre;
	public Vector3 posSeguidor;
	public Vector3 direction;
	public bool nulo = false;
	public float movementSpeed, NuloSpeed;
	Quaternion rotation;
	Vector3 pos;

	void Start(){
		rb = GetComponent<Rigidbody>();
		Seguidor = GameObject.FindGameObjectWithTag("Avion");
	}
	// Update is called once per frame
	void Update(){

		if (Seguidor && !nulo) {
			posSeguidor = Seguidor.transform.position;
			direction = (posSeguidor - transform.position).normalized;
		}

		if(nulo){
		
			rb.velocity = transform.forward * NuloSpeed;
			Tiempo += Time.deltaTime;
			if(Tiempo >= 4){

				Destroy(padre);
			}
		}
	}

	void FixedUpdate () {

		if(Seguidor && !nulo){
		
			rb.MovePosition (transform.position + direction * movementSpeed * Time.deltaTime);
			var rotation = Quaternion.LookRotation (Seguidor.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			transform.rotation = Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0f));
		}else if(!Seguidor){

			nulo = true;
		}
	}

	void OnTriggerEnter (Collider Col){

		if(Col.name == "Nulo"){

			nulo = true;
		}
	
	}
}
