using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	
	Vector3 flyingPath = new Vector3(0, 0, 0);
	public float speed = 15f;

	private GameObject pModel;

	// Use this for initialization
	void Start () {
		pModel = GameObject.Find("Model");
		flyingPath = pModel.transform.forward;
		StartCoroutine("TimeToDie");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(flyingPath * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		print ("Fireball hit something");
		if(collision.gameObject.tag == "Enemy")
		{
			print ("I hit minion 1 with fire!, Health is " + collision.gameObject.GetComponent<SimpleFSM>().health);
			collision.gameObject.GetComponent<SimpleFSM>().health -= 20;
		}
		Destroy (this.gameObject);

	}

	IEnumerator TimeToDie (){
		yield return new WaitForSeconds(2f);
		GameObject.Destroy(this.gameObject);
	}
}
