using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	protected GameObject[] waypoints;

	protected Vector3 destinationpos;

	protected float chasedTime;
	
	GameObject mouse;

	private static System.Random random = new System.Random();

	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		mouse = GameObject.FindGameObjectWithTag("Mouse");
		chasedTime = 0.0f;

		spawn();

	}
	
	// Update is called once per frame
	void Update () {
		UpdateDestination();
	}

	private void UpdateDestination()
	{
		int nextDestination = random.Next(waypoints.Length - 1);
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		
		if (agent.remainingDistance < 1)
		{            
			agent.destination = waypoints[nextDestination].transform.position;

		}
		else if(Vector3.Distance(agent.transform.position, mouse.transform.position) <= 5.0f 
		        && mouse != null )
		{
			agent.destination = mouse.transform.position;
			chasedTime += Time.deltaTime;
			//Debug.Log(chasedTime);
			if(Mathf.FloorToInt(chasedTime) % 5 == 0 && agent.speed < 10){
				agent.speed += 1;
				Debug.Log("Speed increase");
			}
		}

		if(Vector3.Distance(agent.transform.position, mouse.transform.position) <= 1.5f){
			agent.Stop(true);
		}
		
	}

	void spawn(){

		Vector3 randomSpawn = new Vector3(Random.Range(-9.6f, 29.1f), 1.18f, Random.Range(-9.7f, 9.4f));
			gameObject.transform.position = randomSpawn;
		
	}

	protected void FindNextPoint()
	{
		print ("Finding next waypoint");
		int rndIndex = Random.Range (0, waypoints.Length);
		float rndRadius = 5.0f;
		Vector3 rndPosition = Vector3.zero;
		destinationpos = waypoints [rndIndex].transform.position + rndPosition;
		
		if(IsInCurrentRange(destinationpos)){
			rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f,Random.Range (-rndRadius, rndRadius));
			destinationpos = waypoints[rndIndex].transform.position + rndPosition;
		}
	}

	protected bool IsInCurrentRange(Vector3 pos){
		float xPos = Mathf.Abs (pos.x - transform.position.x);
		float zPos = Mathf.Abs (pos.y - transform.position.y);
		
		if(xPos <= 50 && zPos <= 50){
			return true;
		}
		return false;
	}
}
