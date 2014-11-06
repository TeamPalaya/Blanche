using UnityEngine;
using System.Collections;

public class Universe : MonoBehaviour {

	//Input
	public bool key_W = false;
	public bool key_A = false;
	public bool key_S = false;
	public bool key_D = false;
	public bool key_Space = false;
	public bool key_F = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckKeys();
	}

	public void CheckKeys () {
		key_W = Input.GetKey(KeyCode.W);
		key_A = Input.GetKey(KeyCode.A);
		key_S = Input.GetKey(KeyCode.S);
		key_D = Input.GetKey(KeyCode.D);
		key_Space = Input.GetKey(KeyCode.Space);
		key_F = Input.GetKey(KeyCode.F);
	}
	
	public void Move (GameObject moveThis, int direction, float speed) {
		switch(direction){
		case 9:
			//moveThis.transform.LookAt(GameObject.Find("dir9").transform);
			//moveThis.rigidbody.velocity = (moveThis.transform.forward * speed);

			GameObject.Find("CamCube2").transform.LookAt(GameObject.Find("dir9").transform);
			GameObject.Find("CamCube2").transform.forward = new Vector3(transform.forward.x, 0, transform.forward.z);
			moveThis.rigidbody.velocity = (GameObject.Find("CamCube2").transform.forward * speed);
			break;
		case 8:
			moveThis.rigidbody.velocity = (moveThis.transform.forward * speed);
			break;
		case 4:
			moveThis.rigidbody.velocity = (moveThis.transform.right * -speed);
			break;
		case 2:
			moveThis.rigidbody.velocity = (moveThis.transform.forward * -speed);
			break;
		case 6:
			moveThis.rigidbody.velocity = (moveThis.transform.right * speed);
			break;
		default:
			break;
		}
	}

	public void Move (GameObject moveThis, bool isMoving) {
		if (!isMoving){
			moveThis.rigidbody.velocity = new Vector3(0, moveThis.rigidbody.velocity.y, 0);
		}
	}
}
