using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class button : MonoBehaviour {


	private float time;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Joystick2Button15)) {

			SceneManager.LoadScene ("Title");

		}
		time += Time.deltaTime;

		if (time >= 30) {
			SceneManager.LoadScene ("Title");
		}

			
	}

	public void ButtonPush(){

		SceneManager.LoadScene ("Title");

	}
}
