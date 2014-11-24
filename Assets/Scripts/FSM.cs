using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour {

	protected Transform playerposition;

	protected Vector3 destinationpos;

	protected GameObject[] pointList;

	protected float elapsedTime;
	
	protected virtual void Initialize() { }
	protected virtual void FSMUpdate() { }
	protected virtual void FSMFixedUpdate() { }

	void Start(){
		Initialize ();
	}

	void Update(){
		FSMUpdate ();
	}

	void FixedUpdate(){
		FSMFixedUpdate ();
	}
}
