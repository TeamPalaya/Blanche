using UnityEngine;
using System.Collections;

public class BossChaseAI : MonoBehaviour {
	
	protected GameObject[] waypoints;
	
	protected Vector3 destinationpos;
	
	protected float chasedTime;

	protected float bulletTime;
	protected float comboTime;

	public GameObject Bullet;

	protected GameObject player;

	private float shootRate = 0.1f;
	private float comboRate = 2.0f;

	protected Transform bulletSpawnPoint;

	GameObject explosion;

	int bossHealth = 100;

	private static System.Random random = new System.Random();
	
	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		player = GameObject.FindGameObjectWithTag("Player");
		chasedTime = 0.0f;

		bulletSpawnPoint = gameObject.transform.GetChild(0).transform;
		explosion = GameObject.Find("Explosion");


		//spawn();
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDestination();

	}
	
	private void UpdateDestination()
	{
		int nextDestination = random.Next(waypoints.Length - 1);
		NavMeshAgent agent = GetComponent<NavMeshAgent>();

		Quaternion targetRotation = Quaternion.LookRotation(destinationpos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20.0f * Time.deltaTime); 

		if (agent.remainingDistance < 1)
		{            
			agent.destination = waypoints[nextDestination].transform.position;
			
		}
		else if(Vector3.Distance(agent.transform.position, player.transform.position) <= 5.0f )
		{
			agent.destination = player.transform.position;
			ShootBullet();
			chasedTime += Time.deltaTime;

			if (Vector3.Distance(agent.transform.position, player.transform.position) <= 0.8f ){
				ComboAttack();
			}
			//Debug.Log(chasedTime);
			/*if(Mathf.FloorToInt(chasedTime) % 5 == 0 && agent.speed < 10){
				agent.speed += 1;
				Debug.Log("Speed increase");
			}*/
		}


		bulletTime += Time.deltaTime;
		comboTime += Time.deltaTime;
		//print (bulletTime);

		/*if(Vector3.Distance(agent.transform.position, mouse.transform.position) <= 0.5f){
			agent.Stop(true);
		}*/
		
	}
	
	void spawn(){
		
		Vector3 randomSpawn = new Vector3(Random.Range(-9.6f, 29.1f), 1.18f, Random.Range(-9.7f, 9.4f));
		gameObject.transform.position = randomSpawn;
		
	}

	private void ShootBullet()
	{
		if (bulletTime >= shootRate)
		{
			//Shoot the bullet
			Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
			print ("ranged");
			bulletTime = 0.0f;
		}
	}

	private void MeleeAttack(){

		//SpecialEffectsHelper.Instance.Explosion(transform.position);
		//instance.Explosion(transform.position);
		explosion.GetComponent<SpecialEffectsHelper>().Explosion(transform.position);
		print ("melee");
	}


	private void ComboAttack(){
		int i = 0;

		if (comboTime >= comboRate)
		{
			MeleeAttack();
			while(i < 3){
				ShootBullet();
				i++;
			}
			MeleeAttack();
			comboTime = 0.0f;
		}
	}
}
