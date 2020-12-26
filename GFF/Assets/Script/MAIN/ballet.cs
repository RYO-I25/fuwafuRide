using UnityEngine;
using System.Collections;

public class ballet : MonoBehaviour {

	public Transform player;
	public GameObject bullet;
	private float time ;
	public GameObject effect;
//	public GameObject sbullet;

	// 弾丸発射点
	public Transform muzzle;

	// 弾丸の速度
	public float speed = 1000;

	// Use this for initialization
	void Start () {
		time = 0;
	}

	// Update is called once per frame
	void Update () {


		if (time >= 1.0f) {
			effect.GetComponent<ParticleSystem> ().startColor = Color.red;
		}

		if (Input.GetKey (KeyCode.Joystick2Button0)) {
			time += Time.deltaTime;
			effect.SetActive (true);
	
		}if(Input.GetKeyUp (KeyCode.Joystick2Button0)){
			if (time > 1.0f) {


				time = 0;



				gameObject.SetActive (false);
				effect.SetActive (false);
				effect.GetComponent<ParticleSystem> ().startColor = Color.yellow;

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
				bullets.transform.position = muzzle.position + new Vector3 (0, 0, 0);

				bullets1.GetComponent<Rigidbody> ().AddForce (Lforce);
				bullets1.transform.position = muzzle.position + new Vector3 (-0.4f, 0, 0);


				bullets2.GetComponent<Rigidbody> ().AddForce (Rforce);
				bullets2.transform.position = muzzle.position + new Vector3 (0.4f, 0, 0);


			} else {
				time = 0;

				gameObject.SetActive (false);
				effect.SetActive (false);

				// 弾丸の複製
				GameObject bullets = GameObject.Instantiate (bullet)as GameObject;

				Vector3 force;
				force = this.gameObject.transform.up * speed;
				// Rigidbodyに力を加えて発射
				bullets.GetComponent<Rigidbody> ().AddForce (force);
				// 弾丸の位置を調整
				bullets.transform.position = muzzle.position + new Vector3 (0, 0, 0);
				effect.GetComponent<ParticleSystem> ().startColor = Color.yellow;

			}
		}
	}


}
