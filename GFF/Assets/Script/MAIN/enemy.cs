using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject bullet;
	private GameObject player;
	private GameObject cp;
	private GameObject ob;
	public GameObject Random;
	public float speed = 1000;
//	private float move = 1.2f;
	private float time = 0;
	private Rigidbody rg;
//	private float fspeed;
//	public Texture MainVertion;
//	public Texture OtherVertion;
//	private GameObject texture;

	// Use this for initialization
	void Start () {
		player  = GameObject.FindGameObjectWithTag("Player");
		cp  = GameObject.FindGameObjectWithTag("enemy");
		ob = GameObject.FindGameObjectWithTag ("cloud");
		rg = GetComponent<Rigidbody> ();
//		texture = GameObject.FindGameObjectWithTag ("KaeruTexture");
	}
	
	// Update is called once per frame
	void Update () {

		if (player.transform.position.y - cp.transform.position.y > 0.5f) {
			

			if (player.transform.position.x - cp.transform.position.x > 1.4f) {
				rg.AddForce (1,0,0);
			} else if (player.transform.position.x - cp.transform.position.x < -1.4f) {
				rg.AddForce (-1,0,0);
			} else {
				time += Time.deltaTime;
				if (time > 1.5f) {
//					 fspeed = 40;


//					Invoke ("Toziru", 1.0f);
					// 弾丸の複製
					GameObject bullets = GameObject.Instantiate (bullet)as GameObject;
					GameObject bullets1 = GameObject.Instantiate (bullet)as GameObject;
					GameObject bullets2 = GameObject.Instantiate (bullet)as GameObject;

					Vector3 force;
					Vector3 Rforce;
					Vector3 Lforce;
					force = this.gameObject.transform.up * speed;
					Rforce = this.gameObject.transform.up * speed;
					Lforce = this.gameObject.transform.up*speed;

					// Rigidbodyに力を加えて発射
					bullets.GetComponent<Rigidbody> ().AddForce (force);
					bullets.transform.position = transform.position + new Vector3 (0, 0, 0);

					bullets1.GetComponent<Rigidbody> ().AddForce (Lforce);
					bullets1.transform.position = transform.position + new Vector3 (-0.4f, 0, 0);


					bullets2.GetComponent<Rigidbody> ().AddForce (Rforce);
					bullets2.transform.position = transform.position + new Vector3 (0.4f, 0, 0);

					time = 0;
				}
			}
				
		} else if (ob.transform.position.y - cp.transform.position.y < 1.5f && ob.transform.position.y - cp.transform.position.y > -1.5f) {
			
			if (ob.transform.position.x - cp.transform.position.x >= 0 && ob.transform.position.x - cp.transform.position.x < 2.0f) {
				rg.AddForce (1,0,0);
			} else if (ob.transform.position.x - cp.transform.position.x < 0 && ob.transform.position.x - cp.transform.position.x > -2.0f) {
				rg.AddForce (-1,0,0);
			}
		}
		else {
			Rigidbody rigidbody = GetComponent<Rigidbody> ();

			if (Random.transform.position.x - cp.transform.position.x > 0) {
				rigidbody.AddForce (1,0,0);
			} else if (Random.transform.position.x - cp.transform.position.x < 0) {
				rigidbody.AddForce (-1,0,0);
			}


		}




	
	     }

	void FixedUpdate(){
		if (rg.velocity.x > 2.0f) {

			rg.velocity = new Vector3(1,0,0);
		} else if (rg.velocity.x < -2.0f) {
			
			rg.velocity = new Vector3(-1,0,0);
		}

	}

	void Toziru(){
//		texture.GetComponent<Renderer> ().material.mainTexture = MainVertion;
	}
		


}
