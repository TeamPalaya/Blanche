using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour {

	protected Transform playerTransform;

	protected Vector3 destPos;
	protected float shootRate;
	protected float elapsedTime;

	public Transform bulletSpawnPoint{ get; set; }

	protected virtual void Initialize(){ }
	protected virtual void FSMUpdate() { }
	protected virtual void FSMFixedUpdate() { }

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		FSMUpdate ();
	}

	void FiexedUpdate()
	{
		FSMFixedUpdate ();
	}
}
