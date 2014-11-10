using UnityEngine;
using System.Collections;

public class HealthSc : MonoBehaviour {

	//health variables
	public float curHP=100;
	public float maxHP=100;
	public float maxBAR=100;
	public float HealthBarLength;

	//chase varialbes
	public float chaseSpeed;
	public float turn;
	GameObject targetPlayer;
	
	// Use this for initialization
	void Start () {
		targetPlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if(Input.GetMouseButtonDown(0)){
			ChangeHP(-25);
		}
		CloseOnTarget();
	}

	void OnGUI() {
		GUI.Box(new Rect(10, 10, HealthBarLength,25), "");
		HealthBarLength = curHP * maxBAR / maxHP;
	}

	void ChangeHP(float Change) {
		curHP += Change;
		if (curHP > 100) {
			curHP=100;
		}
		if (curHP <= 0) {
			Debug.Log ("Droid Has DIED!");
			Destroy (this.gameObject);
		}
	}

	void CloseOnTarget() {
		if (curHP <= 55 && curHP > 0) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation
			                                      (targetPlayer.transform.position-transform.position), turn * Time.deltaTime);
			
			transform.position += transform.forward*chaseSpeed*Time.deltaTime;
		}
	}

	void  OnTriggerEnter ( Collider other  ){
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			}
		if (other.gameObject.tag == "Bullet") {
			ChangeHP(-25);
		}
	}

	void  OnCollisionEnter ( Collision collision  ){
		if (collision.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}

	/*
	void onTriggerEnter(Collider other) {
		switch (other.gameObject.tag) {
		case "Heal":
			ChangeHP(25);
			break;
		case "Bullet":
			ChangeHP(-25);
			break;
		}
		Destroy (this.gameObject);
	}

	private void  ExplodeSelf (){
		//Instantiate(explosion,transform.position,Quaternion.identity);
		Instantiate(transform.position,Quaternion.identity);
		Destroy(gameObject);
	}

	void CloseOnTarget (){
		if(target != null) {
			Vector3 relativePos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);
			
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, homingSensitivity);
		}
		
		transform.Translate(0,0,chaseSpeed * Time.deltaTime,Space.Self);
	}
	*/
}