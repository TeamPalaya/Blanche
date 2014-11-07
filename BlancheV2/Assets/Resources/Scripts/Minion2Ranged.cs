using UnityEngine;
using System.Collections;

public class Minion2Ranged : MonoBehaviour {

	bool up, down;
	bool left, right;

	public GameObject cam, spin;
	Vector3 forwardDirection;
	Vector3 rightDirection;

	public float rotationSpeed = 3, defaultFlyingSpeed = 5, extraSpeed = 3, bankSpeed = 2;
	public bool flyForwards = false;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Cammy");
		spin = GameObject.Find("Spin");
	}
	
	// Update is called once per frame
	void Update () {
		//check if player is pressing buttons
		CheckKeyStates();

		forwardDirection = cam.transform.forward;
		forwardDirection.y = 0;
		rightDirection = cam.transform.right;
		rightDirection.y = 0;
	}
	
	void FixedUpdate() {

		if (flyForwards)
		{
			transform.Translate (forwardDirection * defaultFlyingSpeed * Time.deltaTime);
		}

		if (up)
		{
			transform.Translate (forwardDirection * extraSpeed * Time.deltaTime);
		}
		if (down)
		{

		}
		if (right)
		{
			spin.transform.Rotate (0, rotationSpeed, 0);
			transform.Translate (rightDirection * bankSpeed * Time.deltaTime);
		}
		if (left)
		{
			spin.transform.Rotate (0, -rotationSpeed, 0);
			transform.Translate (rightDirection * -bankSpeed * Time.deltaTime);
		}
	}

	public void CheckKeyStates(){
		//
		if (Input.GetKey(KeyCode.W)){
			up = true;}
		else{
			up = false;}

		if (Input.GetKey(KeyCode.S)){
			down = true;}
		else{
			down = false;}
		
		if (Input.GetKey(KeyCode.D)){
			right = true;}
		else{
			right = false;}
		
		if (Input.GetKey(KeyCode.A)){
			left = true;}
		else{
			left = false;}
	}
}
