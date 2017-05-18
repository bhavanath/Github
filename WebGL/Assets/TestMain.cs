using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMain : MonoBehaviour {

	public Transform[] CamPoints;
	public float speed;
	public Transform MainView;

	private bool Frontclick = false;
	private bool Rearclick = false;
	private bool Bodyclick = false;
	public Animator anim;
	public GameObject fnt;
	public GameObject body;

	void Start () 
	{
		MainView = CamPoints [3];
		anim = fnt.GetComponent<Animator> ();

	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "cube1") {
					Frontclick = true;
					MainView = CamPoints [0];
					//body.GetComponent<Renderer> ().material.color.a = 0;
					Debug.Log ("cube1");					
				} else
					Frontclick = false;
				if (hit.transform.tag == "cube2") {
					Bodyclick = true;
					MainView = CamPoints [1];
					Debug.Log ("cube2");					
				} else
					Bodyclick = false;	
				if (hit.transform.tag == "cube3") {
					Rearclick = true;
					MainView = CamPoints [2];
					Debug.Log ("cube3");					
				} else
					Rearclick = false;

			}
		}
		if (Input.GetMouseButtonDown (1)) 
		{
			MainView = CamPoints [3];
			 Frontclick = false;
			 Rearclick = false;
			 Bodyclick = false;

		}
		Animations ();
	}

	void LateUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, MainView.position, speed * Time.deltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation, MainView.rotation, speed * Time.deltaTime);
	}

	void Animations()
	{
		if (Frontclick)
			anim.SetBool ("front", true);
		else if (!Frontclick)
			anim.SetBool ("front", false);

					
	}

}
