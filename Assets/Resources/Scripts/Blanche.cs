using UnityEngine;
using System.Collections;

public class Blanche : MonoBehaviour {

	private GameObject universe;
	private Universe universeSS;

	public GameObject camCube2;
	public temptarget camCubeSS;

	public float speed = 10f;
	public bool isMoving = false;

	Vector3 forwardDir;
	Vector3 rightDir;

	public Vector3 beef;

	// Use this for initialization
	void Start () {
		universe = GameObject.Find("Universe");
		universeSS = universe.GetComponent<Universe>();

		camCubeSS = camCube2.GetComponent<temptarget>();
	}
	
	// Update is called once per frame
	void Update () {



		if (universeSS.key_W){
			isMoving = true;
			universeSS.Move(this.gameObject, 8, speed);
		}

		if (universeSS.key_D){
			isMoving = true;
			universeSS.Move(this.gameObject, 6, speed);
		}

		if (universeSS.key_A){
			isMoving = true;
			universeSS.Move(this.gameObject, 4, speed);
		}

		if (universeSS.key_S){
			isMoving = true;
			universeSS.Move(this.gameObject, 2, speed);
		}

		if (!universeSS.key_W && !universeSS.key_D && !universeSS.key_S && !universeSS.key_A){
			isMoving = false;
			universeSS.Move(this.gameObject, isMoving);
		}


		if (universeSS.key_W && universeSS.key_D){
			isMoving = true;
			universeSS.Move(this.gameObject, 9, speed);
		}




		if (universeSS.key_F){
			Debug.Log("FFFFFFFFFFFFFF");
			rigidbody.velocity = (camCubeSS.LookAt9() * speed);
			//transform.LookAt(GameObject.Find("Target").transform);
			//transform.forward = new Vector3(transform.forward.x, 0, transform.forward.z);
		}

		//Debug.Log(rigidbody.velocity);
		//Debug.Log(rigidbody.velocity.magnitude);
	}

	//
	void FixedUpdate () {

	}
}
