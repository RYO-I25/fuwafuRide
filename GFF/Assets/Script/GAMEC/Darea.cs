using UnityEngine;
using System.Collections;

public class Darea : MonoBehaviour {

	private float time;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter (Collider hit)
	{if (hit.CompareTag ("Darea") || hit.CompareTag ("enemy") || hit.CompareTag ("Player")|| hit.CompareTag ("balloon")) {

			Destroy (gameObject);
		}
			

	}
}
