using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	private GameObject player;
	private GameObject enemy;
	public float speed;
	private Vector3 d1;
	private Vector3 d2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("enemy");


		if (player.transform.position.y < enemy.transform.position.y) {

			d1 = transform.position - enemy.transform.position;
			transform.position += -speed * d1.normalized;

		} else if (player.transform.position.y > enemy.transform.position.y) {
			d2 = transform.position - enemy.transform.position;
			transform.position += -speed * d2.normalized;
		}

	}
}
