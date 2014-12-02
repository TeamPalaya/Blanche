using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int speed = 400;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		var camTransform = Camera.main.transform;
		
		Vector3 forward = camTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;
		
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		
		if(Input.GetKey ("w")) {	
			rigidbody.AddForce(forward * speed * Time.deltaTime);
		}
		
		if(Input.GetKey ("s")) {
			rigidbody.AddForce(forward * -speed * Time.deltaTime);
		}
		
		if(Input.GetKey ("d")) {
			rigidbody.AddForce(right * speed * Time.deltaTime);
		}
		
		if(Input.GetKey ("a")) {
			rigidbody.AddForce(right * -speed * Time.deltaTime);
		}
		
		
		if (forward.y == -50){
			//Application.LoadLevel(Application.loadedLevelName);
			
		}
		
		if (rigidbody.position.y <= -50){
			Application.LoadLevel(Application.loadedLevelName);
			
		}

		
	}

	void OnTriggerEnter(Collider other){

		Debug.Log("win");

			
		
	}
}
