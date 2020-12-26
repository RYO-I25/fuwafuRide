using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTower : MonoBehaviour {

	private Vector3 d;
	public GameObject tower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		tower = GameObject.FindGameObjectWithTag ("Tower");

		 d = transform.position - tower.transform.position;
		Invoke ("Move", 1.5f);
	}



	void Move(){


		transform.position += -0.8f*d.normalized;
	}
}
