using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public Transform target;

	public float Zoomspd =5f;
	public Camera cam;
	private Vector3 offset=new Vector3(0,0,-0.68f);
	void Start () 
	{
		
	}
	
	void LateUpdate () {
		
	}

	void OnMouseDown()
	{
		Vector3 dest = target.transform.position + offset;
		cam.transform.position = Vector3.Lerp (transform.position, dest, Zoomspd);
		//Camera.main.fieldOfView -= Zoomspd;
	}
}
