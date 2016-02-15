using UnityEngine;
using System.Collections;

public class lightLogic : MonoBehaviour {

	Light l1;

	// Use this for initialization
	void Start () {
		l1 = GameObject.FindGameObjectWithTag ("light").GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			l1.enabled = !l1.enabled;
		}
	}
}
