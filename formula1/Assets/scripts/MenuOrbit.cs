using UnityEngine;
using System.Collections;

public class MenuOrbit : MonoBehaviour{
	
	public Transform target;
	public float distance = 10.0f;

	public float xSpeed = 125.0f;
	public float ySpeed = 60.0f;

	public float yMinLimit = -5;
	public float yMaxLimit = 5;

	public float xMinLimit = -7;
	public float xMaxLimit = 7;

	private float x = 0.0f;
	private float y = 0.0f;

	void Start () {
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		// Make the rigid body not change rotation
		//~ if (rigidbody) 
		//~ rigidbody.freezeRotation = true;
	}

	void Update () {
		if (target){
			x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
			y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

			y = ClampAngle(y, yMinLimit, yMaxLimit);
			x = ClampAngle(x, xMinLimit, xMaxLimit);

			transform.rotation = Quaternion.Euler(y, x, 0);
//			transform.position = (Quaternion.Euler(y, x, 0)) * new Vector3(0.0f, 0.0f, -distance) + target.position;
		}
	}

	static float ClampAngle(float angle, float min, float max) {
		if (angle < -360){
			angle += 360;
		}
		if (angle > 360){
			angle -= 360;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
