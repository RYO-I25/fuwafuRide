using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

	public GameObject text;
	public GameObject[] effect;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.time = 3.1f;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter (Collider hit)
	{if (hit.CompareTag ("ballet")) {

			Destroy (gameObject);
			Destroy (text);

			for (int i = 0; i < effect.Length; i++) {
				effect[i].SetActive (true);
			}


		}
	}




}
