using UnityEngine;
using System.Collections;

public class SimpleFSM : FSM {

	protected Animator animator;

	public enum FSMState
	{
		None,
		Patrol,
		Chase,
		Attack,
		Dead
	}

	public FSMState currentState;

	private float currentSpeed;

	private float currentrotationSpeed;

	private bool isDead;
	public int health;

	private Vector3 curpos;
	private Vector3 lastpos;

	protected override void Initialize()
	{
		currentState = FSMState.Patrol;
		currentSpeed = 12.0f;
		currentrotationSpeed = 5.0f;
		lastpos = transform.position;
		curpos = transform.position;
		isDead = false;
		elapsedTime = 0.0f;
		health = 100;
		animator = GetComponent<Animator> ();
		animator.SetBool ("Moving", false);

		// Get all Wander Points
		pointList = GameObject.FindGameObjectsWithTag ("PatrolPoint");

		// Get the player
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		playerposition = player.transform;

		if (!playerposition) {
			print ("There is no objects with tag 'Player'");
		}else{
			print ("Found object with tag 'Player'");
		}
	}

	// Update each frame
	protected override void FSMUpdate()
	{
		curpos = transform.position;
		if(animator.GetBool("Attacking") == false){
			CheckMoving ();
		}
		switch(currentState)
		{
			case FSMState.Patrol: UpdatePatrolState(); break;
			case FSMState.Chase: UpdateChaseState(); break;
			case FSMState.Attack: UpdateAttackState(); break;
			case FSMState.Dead: UpdateDeadState(); break;
		}

		// Update Elapsed Time
		elapsedTime += Time.deltaTime;

		// Die if health is 0
		if (health <= 0) {
			currentState = FSMState.Dead;
		}
		lastpos = curpos;
	}

	protected void UpdatePatrolState(){
		if(Vector3.Distance(transform.position, destinationpos) <= 10.0f)
		{
			FindNextPoint();
		}else if(Vector3.Distance(transform.position,playerposition.position) <= 11.0f)
		{
			currentState = FSMState.Chase;
		}

		Quaternion targetRotation = Quaternion.LookRotation (destinationpos - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * currentrotationSpeed);

		transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
	}

	protected void UpdateChaseState(){
		destinationpos = playerposition.position;
		float dist = Vector3.Distance (transform.position, playerposition.position);

		if(dist <= 10.0f){
			currentState = FSMState.Attack;
		}
		else if(dist >= 11.0f){
			currentState = FSMState.Patrol;
		}

		transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
	}

	protected void UpdateAttackState(){
		destinationpos = playerposition.position;

		float dist = Vector3.Distance (transform.position, playerposition.position);
		if(dist >= 0.0f && dist <= 10.0f){
			animator.SetBool ("Moving", false);
			animator.SetBool ("Attacking", true);
			Quaternion targetRotation = Quaternion.LookRotation(destinationpos - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation,targetRotation,Time.deltaTime * currentrotationSpeed);
			transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
			currentState = FSMState.Attack;
		}else if(dist >= 5.0f){
			currentState = FSMState.Chase;
		}
	}

	protected void UpdateDeadState(){
		if (!isDead) {
			isDead = true;
		}
	}

	protected void FindNextPoint()
	{
		int rndIndex = Random.Range (0, pointList.Length);
		float rndRadius = 5.0f;
		Vector3 rndPosition = Vector3.zero;
		destinationpos = pointList [rndIndex].transform.position + rndPosition;

		if(IsInCurrentRange(destinationpos)){
			rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f,Random.Range (-rndRadius, rndRadius));
			destinationpos = pointList[rndIndex].transform.position + rndPosition;
		}
	}

	protected bool IsInCurrentRange(Vector3 pos){
		float xPos = Mathf.Abs (pos.x - transform.position.x);
		float zPos = Mathf.Abs (pos.y - transform.position.y);

		if(xPos <= 150 && zPos <= 150){
			return true;
		}
		return false;
	}

	private void CheckMoving()
	{

		if(curpos != lastpos)
		{
			animator.SetBool ("Moving", true);
		}else{
			animator.SetBool ("Moving", false);
		}
	}
}
