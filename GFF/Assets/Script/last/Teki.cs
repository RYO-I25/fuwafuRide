using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teki : MonoBehaviour {

	public float cycle = 30;
	public float time;
	private float speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cycle = transform.rotation.x;
		transform.Rotate (Vector3.left*speed , Space.Self);

		if(cycle >= 0.27f){
			speed = 0;

			time += Time.deltaTime;

			if (time >= 1) {

				speed = 2f;

			}
		}else if(cycle <=-0.5f){
			speed = -20;
			time = 0;
		}





			
	}
}
