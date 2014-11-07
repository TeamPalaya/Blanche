using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject Explosion;

	public float speed = 0.05f;
	public float LifeTime = 5.0f;
	
	public int damage = 20;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, LifeTime);
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
		print ("Bullet position = " + transform.position.x + " " + transform.position.y + " " + transform.position.z);
	}
	
	// Destroy bullet
	void OnCollisionEnter(Collision collision)
	{
		ContactPoint contact = collision.contacts [0];
		Destroy (gameObject);
	}
}
