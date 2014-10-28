#pragma strict

function Start () {

}

var ShootFireBallPrefab:Transform;

function Update() 
{
	if(Input.GetButtonDown("Jump"))
	{
		var ShootFireBall = Instantiate(ShootFireBallPrefab, GameObject.Find("SpawnPoint").transform.position, Quaternion.identity);
	
		ShootFireBall.rigidbody.AddForce(transform.forward * 2000);
	}
}