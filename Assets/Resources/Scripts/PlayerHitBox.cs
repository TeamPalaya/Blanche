using UnityEngine;
using System.Collections;

public class PlayerHitBox : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			print ("I got hit! Health is now " + player.GetComponent<Blanche>().health);
			player.GetComponent<Blanche>().damageTimer = 0.0f;
			player.GetComponent<Blanche>().health -= 5;
		}
	}
}
