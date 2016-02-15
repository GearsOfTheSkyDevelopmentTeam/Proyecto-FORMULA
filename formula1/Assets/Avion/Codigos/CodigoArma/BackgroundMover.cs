using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {
	public int nBG = 2;
	public float MovPosicionX = 1;//368
	public bool opcion = true;

	void OnTriggerEnter(Collider coll){

		if(opcion == false){
			if(coll.name == ("IA(Clone)")){

				//Debug.Log ("AQUI!!");
				Destroy (coll.gameObject);
			}
		}
		if(opcion == true){
			if(coll.tag == ("ciudad")){
				
				float largoAmbiente = ((BoxCollider)coll).size.x;
				//Debug.Log ("LargoAmbiente: " + largoAmbiente);
				Vector3 pos = coll.transform.position;
				pos.x += (MovPosicionX * nBG);
				coll.transform.position = pos;
			}
		}
	}
}
