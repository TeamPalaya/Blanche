using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform destination;

	// Update is called once per frame
	void Update () {
		transform.GetComponent<NavMeshAgent>().destination = destination.transform.position;
	}
}
