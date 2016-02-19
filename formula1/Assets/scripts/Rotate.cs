using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour{
	public Transform target;
	public float smoothTime = 0.3F;
//	private float yVelocity = 0.0F;
	public float orbitDegrees = 50f;
	public float damp = 5f;

	void Update(){
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if(input.x != 0){
			transform.position = RotatePointAroundPivot(transform.position, transform.parent.position, Quaternion.Euler(0, -Mathf.Sign(input.x) * orbitDegrees * Time.deltaTime, 0));
		}
		if(input.y != 0){
			float newY = Mathf.Lerp(transform.position.y, input.y > 0 ? 3f : 1f,  Time.deltaTime);
			transform.position = new Vector3(transform.position.x, newY, transform.position.z);
		}
		SmoothLook(target.position);
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle){
		return angle * (point - pivot) + pivot;
	}

	void SmoothLook(Vector3 newDirection){
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), damp * Time.deltaTime);
	}
}