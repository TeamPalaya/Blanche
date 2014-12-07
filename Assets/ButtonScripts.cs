using UnityEngine;
using System.Collections;

public class ButtonScripts : MonoBehaviour {

	public GameObject optionsMenu, panel;

	// Use this for initialization
	void Start () {
		//AudioSource.PlayClipAtPoint(new AudioClip().name(""), transform.position);


	}
	
	// Update is called once per frame
	void Update () {


	}

	public void StartGame(){
		print ("load level");
		Application.LoadLevel("LoadedLevel");
	}

	public void ExitGame(){
		print ("sdfkjsdfkjsfd");
		Application.Quit();
	}

	public void ViewOptions(){
		optionsMenu.SetActive(true);

	}

	public void backButton(){
		optionsMenu.SetActive(false);

	}
}
