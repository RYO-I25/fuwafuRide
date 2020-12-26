using UnityEngine;
using System.Collections;

public class halfPosition : MonoBehaviour {

	private GameObject player;
	private GameObject enemy;



	// Use this for initialization
	void Start () {
		player  = GameObject.FindGameObjectWithTag("Player");
		enemy  = GameObject.FindGameObjectWithTag("enemy");

	}
	
	// Update is called once per frame
	void Update () {
		transform.position =new Vector3(transform.position.x,(player.transform.position.y + enemy.transform.position.y) / 2,transform.position.z);
	}
}
