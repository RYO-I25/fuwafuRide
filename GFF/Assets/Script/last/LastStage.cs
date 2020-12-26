using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastStage : MonoBehaviour {


	private float dist;
	private GameObject player;
	private GameObject enemy;
	public GameObject pause;
	public GameObject goalText;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("enemy");


	}
	
	// Update is called once per frame
	void Update () {
		dist = enemy.transform.position.y - player.transform.position.y;
	}

	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player")) {
			if (SceneManager.GetActiveScene ().name == "play") {
				
//				pause.GetComponent<Pausable> ().pausing = true;
				SceneManager.LoadScene ("Tower");
			} else if (SceneManager.GetActiveScene ().name == "Tower") {
				
				Invoke ("Goal", 2.0f);
				goalText.SetActive (true);
				gameObject.GetComponent<AudioSource> ().enabled = true;
				player.GetComponent<AudioSource> ().enabled = false;
				pause.GetComponent<Pausable> ().pausing = true;

			}
		}


		if(hit.CompareTag("enemy")){
			if(SceneManager.GetActiveScene ().name == "play") {
				GameObject en = enemy.GetComponent<upmove> ().Cplayer;
				en.GetComponent<MeshFilter> ().mesh = null;

			}
		}
	}

	void Goal(){
		if (dist < 0) {
			SceneManager.LoadScene ("WinEnd");
		} else {
			SceneManager.LoadScene ("LostEnd");
		}
	}
}
