using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    //Explosion Effect
    public GameObject Explosion;

    public float Speed = 0.2f;
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
        ContactPoint contact = collision.contacts[0];
        Instantiate(Explosion, contact.point, Quaternion.identity);
        Destroy(gameObject);
    }
}