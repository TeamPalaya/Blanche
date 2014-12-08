using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private Universe universeSS;
	public Vector3 rotationSwordSwing1 = new Vector3 (0, 180, 0);
	public bool swinging = false;
	public float swingSpeed = 10f;
	public GameObject sword;

	// Use this for initialization
	void Start () {
		universeSS = GameObject.Find("Universe").GetComponent<Universe>();
		sword = GameObject.Find("Sword");
		transform.localEulerAngles = rotationSwordSwing1;
		sword.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		CheckInput();
	}

	//
	void CheckInput () {
		if (universeSS.key_J && !swinging){
			StartCoroutine("Swing");
		}

	}

	void OnTriggerEnter(Collider collision)
	{
		SimpleFSM sfsm = (SimpleFSM)collision.GetComponent (typeof(SimpleFSM));
		Minion3FSM m3fsm = (Minion3FSM)collision.GetComponent (typeof(Minion3FSM));
		if(collision.gameObject.tag == "Enemy" && swinging == true)
		{
			if(m3fsm != null)
			{
				print ("I hit minion 3, Health is " + collision.GetComponent<Minion3FSM>().health);
				collision.GetComponent<Minion3FSM>().health -= 10;
			}else if(sfsm != null)
			{
				print ("I hit minion 1, Health is " + collision.GetComponent<SimpleFSM>().health);
				collision.GetComponent<SimpleFSM>().health -= 20;
			}

		}
	}

	IEnumerator Swing () {
		swinging = true;
		sword.GetComponent<MeshRenderer>().enabled = true;
		do{
			transform.Rotate(0, -swingSpeed, 0);
			yield return null;
		}while(transform.localEulerAngles.y >= 1f);
		yield return new WaitForSeconds(0.1f);
		sword.GetComponent<MeshRenderer>().enabled = false;
		transform.localEulerAngles = rotationSwordSwing1;
		swinging = false;
	}
}
