using UnityEngine;
using System.Collections;

public class MovEnemigoDown : MonoBehaviour {
	public float VeloDown = 10.0f;
	public float VeloHorizontal;
	public Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {

		rb.AddForce (transform.right * VeloHorizontal);
		rb.AddForce (transform.up * VeloDown *-1);
	}
}
