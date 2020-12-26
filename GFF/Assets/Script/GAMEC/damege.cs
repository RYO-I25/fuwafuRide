using UnityEngine;
using System.Collections;

public class damege : MonoBehaviour {

	private float time;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 0.3f) {
			time = 0;
			gameObject.SetActive (false);
		}
	}
}
