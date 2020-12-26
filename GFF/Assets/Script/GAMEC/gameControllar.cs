using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class gameControllar : MonoBehaviour {



	public GameObject shot;
	public GameObject cloud;
	private GameObject obj;
	private GameObject player;
	private GameObject enemy;


	// Use this for initialization
	void Start () {



		if (SceneManager.GetActiveScene ().name == "Tower") {
			float Dist = upmove.lastDist;

			player = GameObject.FindGameObjectWithTag ("Player");
			enemy = GameObject.FindGameObjectWithTag ("enemy");

			if (Dist > 0) {
				player.transform.position -= new Vector3(0, Dist ,0); 

			} else if (Dist < 0) {

				enemy.transform.position += new Vector3 (0, Dist, 0);

			}




		}





		for (int i = 0; i < 60; i++) {


			float x = Random.Range(20.0f, 30.0f)*3;
			float y = Random.Range(-2.0f, 10.0f)*11;
			float z = Random.Range(-3.0f, 1.0f)*20;

			if (z > -18.0f && z < 6.0f) {

				z = 0;

			}

			float C = Random.Range(5.0f, 15.0f)*10;


			obj = Instantiate (cloud, new Vector3 (x, y, z), transform.rotation);
			obj.GetComponent<cloudmove>(). time =  Random.Range(20, 30);
			obj.transform.localScale += new Vector3 (C, C, C);

		}


	}

	// Update is called once per frame
	void Update () {




		int count = GameObject.FindGameObjectsWithTag ("shot").Length;
		if (count<1){
			gameObject.GetComponent <timer> ().enabled = true;

		}	
			


		}



	}