using UnityEngine;
using System.Collections;

public class addforce : MonoBehaviour {

	private Rigidbody rg;
	private float speed = 15;

	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rg.AddForce (transform.up * speed);
	}
}
