using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private GameObject universe;
	private Universe universeSS;

	// Use this for initialization
	void Start () {
		universe = GameObject.Find("Universe");
		universeSS = universe.GetComponent<Universe>();

		//Make the bullet fly forwards @start
		//universeSS.Move(this.gameObject, 8, 70f);
	}
	
	// Update is called once per frame
	void Update () {
		//universeSS.Move(this.gameObject, 8, 10f);
	}
}
