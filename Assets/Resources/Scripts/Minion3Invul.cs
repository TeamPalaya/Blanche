using UnityEngine;
using System.Collections;

public class Minion3Invul : MonoBehaviour {

	public Collider blancheMeleeAttack;
	public Collider blanchRangedAttack;

	public bool isGuarding = false;
	public bool isInvul = false;

	public GameObject minion3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollision (Collision other){
		if (isGuarding){
			if (other.collider == blancheMeleeAttack || other.collider == blanchRangedAttack && !isInvul){
				isInvul = true;
				StartCoroutine("InvulTimer");
			}
			StartCoroutine("GuardTimer");
		}
	}

	IEnumerator InvulTimer (){
		yield return new WaitForSeconds(2f);
		isInvul = false;
	}

	IEnumerator GuardTimer (){
		yield return new WaitForSeconds(4f);
		isGuarding = false;
	}
}
