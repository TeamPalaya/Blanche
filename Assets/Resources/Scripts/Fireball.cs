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
		SimpleFSM sfsm = (SimpleFSM)collision.gameObject.GetComponent (typeof(SimpleFSM));
		Minion3FSM m3fsm = (Minion3FSM)collision.gameObject.GetComponent (typeof(Minion3FSM));
		Minion4FSM m4fsm = (Minion4FSM)collision.gameObject.GetComponent (typeof(Minion4FSM));
		if(collision.gameObject.tag == "Enemy")
		{
			if(m3fsm != null)
			{
				print ("I hit minion 3, Health is " + collision.gameObject.GetComponent<Minion3FSM>().health);
				collision.gameObject.GetComponent<Minion3FSM>().health -= 10;
			}else if(sfsm != null)
			{
				print ("I hit minion 1, Health is " + collision.gameObject.GetComponent<SimpleFSM>().health);
				collision.gameObject.GetComponent<SimpleFSM>().health -= 20;
			}else if(m4fsm != null)
			{
				print ("I hit minion 4, Health is " + collision.gameObject.GetComponent<Minion4FSM>().health);
				collision.gameObject.GetComponent<Minion4FSM>().health -= 10;
			}
		}
		Destroy (this.gameObject);

	}

	void OnTriggerEnter(Collider collision)
	{
		Minion4FSM m4fsm = (Minion4FSM)collision.gameObject.GetComponent (typeof(Minion4FSM));
		if(m4fsm != null)
		{
			print ("I hit minion 4, Health is " + collision.gameObject.GetComponent<Minion4FSM>().health);
			collision.gameObject.GetComponent<Minion4FSM>().health -= 20;
			Destroy (this.gameObject);
		}
	}
	
	IEnumerator TimeToDie (){
		yield return new WaitForSeconds(2f);
		GameObject.Destroy(this.gameObject);
	}
}
