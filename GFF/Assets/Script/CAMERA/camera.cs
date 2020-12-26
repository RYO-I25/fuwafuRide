using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class camera : MonoBehaviour {

	//tagert1は自分の風船、2は相手の座標、3はその２つの中間の座標
	public Transform target1;
	public Transform target2;
	public Transform target3;
	private Vector3 D;
	public GameObject SIcon;
	public GameObject GIcon;
	private Vector3 Spos1;
	private Vector3 Spos2;
	private GameObject cloud;
	public GameObject planet;
	public bool ON = false;
	public Vector3 Pos;
	private float met;
	private Transform tr; 
	private GameObject player;

	//カメラ自身のTransform変数

	void Start () {

		tr = GetComponent<Transform>();
		Spos1 = SIcon.transform.position;
		Spos2 = GIcon.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");

	}



	void LateUpdate () {

		cloud = GameObject.FindGameObjectWithTag ("cloud");


		if(Input.GetKey(KeyCode.Joystick2Button15)){
			ON = true;
		}if (Input.GetKeyUp (KeyCode.Joystick2Button15)) {
			ON = false;
		}

		if (ON == true) {
			gameObject.GetComponent<Camera> ().fieldOfView = 90;
			tr.position = new Vector3(target1.position.x,target1.position.y,-1) + Pos;
			tr.rotation = Quaternion.Euler (-60, 0, 0);
			tr.LookAt (target1);
		}

		if (ON == false) {

			D = new Vector3 (0, target1.transform.position.y, 0) - new Vector3 (0, target2.transform.position.y, 0);




				tr.LookAt (target3);



			tr.position = target3.position + new Vector3 (0, (target1.transform.position.y - target2.transform.position.y)*1.2f+0.5f , -1.5f);
			//２つの風船の中間の座標に注目している
			

			 met = D.magnitude;
			gameObject.GetComponent<Camera> ().fieldOfView = Mathf.Clamp(90 -  met*2,10,90);


		}

		if (SceneManager.GetActiveScene ().name == "play") {
			if (player.transform.position.y > 109) {
			
				planet.SetActive (true);
				Destroy (cloud);
				gameObject.GetComponent<Camera> ().backgroundColor -= new Color (0.015f, 0.02f, 0.02f, 0);
				gameObject.GetComponent<AudioSource> ().enabled = true;

			}

			if (player.transform.position.y > 150) {
				ON = true;

			}
		}





		SIcon.transform.position = Spos1 + new Vector3 (0, target1.transform.position.y, 0)*3;
		GIcon.transform.position = Spos2 + new Vector3 (0, target2.transform.position.y, 0)*3;

	}
}
	