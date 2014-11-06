using UnityEngine;
using System.Collections;

public class SimpleFSM : FSM {

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
	private int health;

	protected override void Initialize()
	{
		curState = FSMState.None;
		curRotSpeed = 2.0f;
		isDead = false;
		elapsedTime = 0.0f;
		shootRate = 1.0f;
		health = 100;

		GameObject objPlayer = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = objPlayer.transform;

		if (!playerTransform)
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
		destPos = playerTransform.position;
		float dist = Vector3.Distance (transform.position, playerTransform.position);

		if(dist <= 800.0f)
		{
			print ("Enemy Spotted! Engaging");
			curState = FSMState.Attack;
		}else
		{
			print ("Stand-by");
			curState = FSMState.None;
		}
		// Insert ambush code here
		// ~ To Alex
	}

	protected void UpdateAttackState()
	{
		destPos = playerTransform.position;
		float dist = Vector3.Distance (transform.position, playerTransform.position);
		if (dist >= 400.0f && dist < 800.0f) 
		{
			curState = FSMState.Attack;
		}else if(dist >= 800.0f)
		{
			curState = FSMState.None;
		}

		print ("Firing!");
		Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		shootBullet ();
	}

	protected void UpdateDeadState()
	{
		if(!isDead)
		{
			isDead = true;
			Explode();
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

	protected void Explode()
	{
		float rndX = Random.Range (10.0f, 30.0f);
		float rndZ = Random.Range (10.0f, 30.0f);
		for(int i = 0; i < 3; i++)
		{
			rigidbody.AddExplosionForce(1000.0f, transform.position - new Vector3(rndX, 10.0f,rndZ),40.0f,10.0f);
			rigidbody.velocity = transform.TransformDirection(new Vector3(rndX, 20.0f, rndZ));
		}
	}
}
