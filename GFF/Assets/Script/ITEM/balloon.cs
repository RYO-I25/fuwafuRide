using UnityEngine;
using System.Collections;

public class balloon : MonoBehaviour {

	public GameObject[] item;
	public GameObject effect;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider hit)
	{if (hit.CompareTag ("Player") || hit.CompareTag ("enemy")|| hit.CompareTag ("ballet")) {

			Destroy (gameObject);
			Instantiate(item[Random.Range (0, item.Length)],gameObject.transform.position,gameObject.transform.rotation);
			Instantiate (effect, gameObject.transform.position, gameObject.transform.rotation);


		}
}




}