using UnityEngine;
using System.Collections;

public class LooakAtJugador : MonoBehaviour {
	public Transform LookSeguidor;
	public float damping = 5.0f;
	public Transform MyTransform;
	Quaternion rotation;
	Vector3 pos;

	void FixedUpdate () {

		if (MovObjetoPunto.BlockMov == false) {
			if (MovObjetoPunto.Click == true) {
			
				rotation = Quaternion.LookRotation (LookSeguidor.position - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
				transform.rotation = Quaternion.Euler (new Vector3 (0f, transform.eulerAngles.y, 0f));
			} 
		}
	}
}
