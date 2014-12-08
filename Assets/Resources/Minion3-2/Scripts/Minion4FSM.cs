using UnityEngine;
using System.Collections;

public class Minion4FSM : FSM {

	public enum FSMState
	{
		None,
		Attack,
		Dead,
	}

	public FSMState curState;

	private float curRotSpeed;

	public GameObject Bullet;

	private bool isDead;
	public int health;

	protected override void Initialize()
	{
		curState = FSMState.None;
		curRotSpeed = 2.0f;
		isDead = false;
		elapsedTime = 0.0f;
		shootRate = 0.5f;
		health = 100;

		GameObject objPlayer = GameObject.FindGameObjectWithTag ("Player");
		playerposition = objPlayer.transform;

		if (!playerposition)
						print ("Player doesn't exist. Please add one with Tag named 'Player'");

		bulletSpawnPoint = gameObject.transform.GetChild (0).transform;
	}

	protected override void FSMUpdate()
	{
		switch (curState) 
		{
			case FSMState.Attack : UpdateAttackState(); break;
			case FSMState.Dead: UpdateDeadState(); break;
			case FSMState.None : UpdateIdleState(); break;
		}

		elapsedTime += Time.deltaTime;

		if (health <= 0)
			curState = FSMState.Dead;
	}

	protected void UpdateIdleState()
	{	
		destPos = playerposition.position;
		float dist = Vector3.Distance (transform.position, playerposition.position);

		if(dist <= 15.0f)
		{
			curState = FSMState.Attack;
		}else
		{
			curState = FSMState.None;
		}
		// Insert ambush code here
		// ~ To Alex
	}

	protected void UpdateAttackState()
	{
		destPos = playerposition.position;
		float dist = Vector3.Distance (transform.position, playerposition.position);
		if (dist >= 0.0f && dist < 15.0f) 
		{
			curState = FSMState.Attack;
		}else if(dist >= 16.0f)
		{
			curState = FSMState.None;
		}

		//print ("Firing!");
		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		shootBullet ();
	}

	protected void UpdateDeadState()
	{
		if(!isDead)
		{
			isDead = true;
			Destroy(this.gameObject);
		}
	}

	private void shootBullet()
	{
		if(elapsedTime >= shootRate)
		{
			Instantiate(Bullet, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
			elapsedTime = 0.0f;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collider.gameObject.tag == "Bullet")
			health -= collision.gameObject.GetComponent<Bullet>().damage;
	}
}
