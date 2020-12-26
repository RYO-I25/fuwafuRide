using UnityEngine;
using System.Collections;

public class meteo : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	public GameObject fire;


	// Use this for initialization
	void Start () {
		fire.GetComponent<ParticleSystem> ().Play();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, -0.01f, 0);
		transform.Rotate (Vector3.up*5 ,Space.Self);

	}
		
		


}
