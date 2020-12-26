using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

	public Transform target;
	private float time;

	// Use this for initialization
	void Start () {


		transform.position = new Vector3(Random.Range(-2.0f, 2.0f), target.transform.position.y, -1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 1.5f) {
			transform.position = new Vector3 (Random.Range (-2.0f, 2.0f), target.transform.position.y, -1.0f);
			time = 0;
		}
	}
}
