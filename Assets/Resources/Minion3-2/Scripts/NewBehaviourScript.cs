using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private SphereCollider col;
	//private GameObject turret, body;
	public GameObject shield;

	// Use this for initialization
	void Start () {
		/*turret = GameObject.Find("Head");
		body = GameObject.Find("Body");

		turret.renderer.enabled = false;
		body.renderer.enabled = false;*/

		col = (SphereCollider)gameObject.collider;
		col = transform.GetComponent<SphereCollider>();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		//col.radius = 10;
		if (other.tag == "Player"){
			Debug.Log("entered");
			shield.SetActive(true);
		}
		//Debug.Log(col.radius.ToString());
	}

	void OnTriggerExit(){
		shield.SetActive(false);
	}
}
