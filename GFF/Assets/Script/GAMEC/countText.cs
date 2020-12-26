using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countText : MonoBehaviour {
	
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject start;
	public Text startText;
//	public Text pointText;
	public Text DistText;
	private float time;
	private GameObject player;
	private GameObject enemy;
	public GameObject goal;
//	private GameObject c;
	public int Ppoint;
	public int Epoint;
//	private float count; 


	// Use this for initialization
	void Start () {
		time = 2.5f;
		player  = GameObject.FindGameObjectWithTag("Player");
		enemy  = GameObject.FindGameObjectWithTag("enemy");
//		c = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	// Update is called once per frame
	void Update () {

		float dist = goal.transform.position.y - player.transform.position.y;

		if (SceneManager.GetActiveScene ().name == "play") {
			DistText.text = "塔まであと" + dist.ToString ("N0") + "M";

		}if (SceneManager.GetActiveScene ().name == "Tower") {


			DistText.text = "ゴールまであと" + dist.ToString ("N0") + "M";
		}
//		pointText.text = "当てた数:"+ Epoint.ToString() + ",当てられた数:"+ Ppoint.ToString();

		time -= Time.deltaTime;


		if (time <= 1.5f) {
			three.SetActive (false);
			two.SetActive (true);
		}
		if (time <= 0.5f) {
			two.SetActive (false);
			one.SetActive (true);
		}

		if (time <= -0.5f) {
			one.SetActive (false);
			start.SetActive (true);
//			sText.SetActive (false);
			startText.text = "Start!";
//			start.SetActive (true);
//			gameObject.GetComponent <Gamecontrollar> ().enabled = true;

		}  if (time <= -1.5f && time >= -2.5f) {
			Destroy (start);
			foreach (MonoBehaviour mono in player.GetComponents(typeof(MonoBehaviour)) ) {
				mono.enabled = true;
			player.GetComponent<AudioSource> ().enabled = true;
			enemy.GetComponent <upmove> ().enabled = true;
			enemy.GetComponent <enemy> ().enabled = true;
			}
		}

	}

	public void AddPoint(int count){
		Ppoint = Ppoint + count;
	}public void AddPoint1(int count){
		Epoint = Epoint + count;
	}
}
