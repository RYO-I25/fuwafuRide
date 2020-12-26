using UnityEngine;
using System.Collections;

using UnityStandardAssets.ImageEffects;

public class brightness : MonoBehaviour {

	private float time;
	private float speed =2.0f;

	// Use this for initialization
	void Start () {
		time = 0;

	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;

	
			gameObject.GetComponent<Bloom> ().bloomIntensity += Time.deltaTime*speed ;


	}
}
