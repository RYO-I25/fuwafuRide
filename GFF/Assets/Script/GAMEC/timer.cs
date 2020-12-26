using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	private float time;
	public GameObject shot;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {


		time += Time.deltaTime;

		if(time > 1.5f){
			shot.SetActive (true);
			gameObject.GetComponent <timer> ().enabled = false;
			time = 0;
	}
}
}