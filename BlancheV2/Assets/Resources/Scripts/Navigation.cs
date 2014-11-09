using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public bool lookAtPlayer = false;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<NavMeshAgent>().destination = GameObject.Find("Goal").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAtPlayer){
			transform.LookAt(GameObject.Find("Player").transform);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "Player"){
			lookAtPlayer = true;
		}
	}
}
