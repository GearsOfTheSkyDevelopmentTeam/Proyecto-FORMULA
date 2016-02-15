using UnityEngine;
using System.Collections;

public class DestruccionParticula : MonoBehaviour {
	private float tiempo;
	public int limite;

	void Update () {
	
		tiempo += Time.deltaTime;
		if(tiempo >= limite){

			Destroy(this.gameObject);
		}
	}
}
