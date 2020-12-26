using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    const float MAX_MOVEPOS_X = 4.0f;
	private float speed =0.05f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		if (SceneManager.GetActiveScene ().name == "play") {
			gameObject.GetComponent<AudioSource> ().pitch = 0.8f;
		}

        if (transform.position.x > -MAX_MOVEPOS_X) {
			

			if (Input.GetKey (KeyCode.Joystick1Button0)) {
				transform.position += new Vector3(-speed,0,0);
			}

		}
        if (transform.position.x < MAX_MOVEPOS_X) {
				

			if (Input.GetKey (KeyCode.Joystick1Button3)) {
				transform.position += new Vector3(speed,0,0);
			
		}

				
	}

}

	void OnGUI()
	{
		for (int i = (int)KeyCode.Joystick1Button0; i <= (int)KeyCode.Joystick2Button19; i++)
		{
			if (Input.GetKey((KeyCode)i)) GUILayout.Label(((KeyCode)i).ToString() + " is pressed.");
		}
	}

}