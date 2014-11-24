using UnityEngine;
using System.Collections;

public class HealthSc : MonoBehaviour {

	//health variables
	public float curHP=100;
	public float maxHP=100;
	public float maxBAR=100;
	public float HealthBarLength;

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if(Input.GetMouseButtonDown(0)){
			ChangeHP(-25);
		}
	}

	void OnGUI() {
		GUI.Box(new Rect(920, 10, HealthBarLength,25), "");
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
}