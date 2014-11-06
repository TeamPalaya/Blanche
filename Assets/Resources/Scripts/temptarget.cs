using UnityEngine;
using System.Collections;

public class temptarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public Vector3 LookAt9 () {
		transform.LookAt(GameObject.Find("dir9").transform);
		transform.forward = new Vector3(transform.forward.x, 0, transform.forward.z);
		return transform.forward;
	}
}
