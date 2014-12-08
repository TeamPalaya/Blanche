using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	private GameObject turret, body;

	// Use this for initialization
	void Start () {
		turret = GameObject.Find("Head");
		body = GameObject.Find("Body");
		
		turret.renderer.enabled = false;
		body.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "Player"){
			turret.renderer.enabled = true;
			body.renderer.enabled = true;

			Debug.Log("rendered");
		}
	}
}
