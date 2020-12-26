using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

	private Vector3 StartPos;
	public GameObject fir;
	private GameObject fires;
	private Vector3 force;
	public Transform muzzle;
	private Rigidbody rg;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", 0,2.0f);
//		StartPos = this.transform.position + new Vector3 (-0.5f, 0.85f, 0.18f);
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate (Vector3.down*0.1f);
		rg.AddForce (force);
	}

	void Fire(){
		
		fires = Instantiate (fir, muzzle.position, fir.transform.rotation); 
		rg = fires.GetComponent<Rigidbody> ();
		force = this.gameObject.transform.forward ;
		fires.transform.parent = transform;
	}
}
