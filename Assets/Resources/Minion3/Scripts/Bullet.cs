using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject Explosion;

	public float speed = 0.05f;
	public float LifeTime = 5.0f;
	
	public int damage = 10;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, LifeTime);
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}
	
	// Destroy bullet
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			print("Player is hit by bullet! Player health is now " + collision.gameObject.GetComponent<Blanche>().health);
			collision.gameObject.GetComponent<Blanche>().health -= damage;
		}
		if (collision.gameObject.tag != "Enemy") 
		{
			Destroy (gameObject);
		}

	}
}
