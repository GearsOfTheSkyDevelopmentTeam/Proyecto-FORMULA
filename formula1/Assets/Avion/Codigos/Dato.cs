using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dato{
	private Vector3 v;
	private bool b;

	public Dato(float x, float y, float z){
		v = new Vector3(x, y, z);
		b = true;
	}

	public Dato(){
		v = new Vector3(0, 0, 0);
		b = false;
	}

	public Vector3 obtV(){
		return(new Vector3(v.x, v.y, v.z));
	}

	public bool obtB(){
		return(b);
	}
}
