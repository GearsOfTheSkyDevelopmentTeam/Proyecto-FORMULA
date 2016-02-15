using UnityEngine;
using System.Collections;

public class exploAvion : MonoBehaviour {
	public Rigidbody rb;
	public float Gravedad;
	static public bool Activar = false;
	public float magnitudVelo;
	public float Lvelo = 10.0f;
	public GameObject Principal;
	public Transform ExploEsfera;


	void Start(){

		rb = Principal.GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate() {
		if (Activar == true) {
		
			//rbCuerpo.AddForce (transform.up * Gravedad );
			gameObject.layer = 9;
			rb.isKinematic = true;
		} 
	}
}
