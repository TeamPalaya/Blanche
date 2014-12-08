using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    
    public float Speed = 20.0f;
    public float LifeTime = 5.0f;
    public int damage = 0;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        transform.position += 
			transform.forward * Speed * Time.deltaTime;       
    }

    void OnCollisionEnter(Collision collision)
    {
		//print (collision.gameObject.tag);
        ContactPoint contact = collision.contacts[0];
		if (collision.gameObject.tag == "Player"){
			print ("contact");
		}

        Destroy(gameObject);
    }
}