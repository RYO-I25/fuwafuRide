using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movie : MonoBehaviour {

//	private GameObject tower;
	private GameObject player;
	private GameObject enemy;


	// Use this for initialization
	void Start () {
		
//		tower = GameObject.FindGameObjectWithTag("tower");
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("enemy");

	}


	void OnTriggerEnter(Collider hit){

		if (hit.CompareTag ("Player")) {

			player.GetComponent<upmove> ().enabled = false;
			player.GetComponent<player>().enabled = false;
			player.AddComponent<moveTower>();


		}  if (hit.CompareTag ("enemy")) {
			enemy.GetComponent<upmove> ().enabled = false;
			enemy.GetComponent<enemy>().enabled = false;
			enemy.AddComponent<moveTower>();



			}
		}



}
