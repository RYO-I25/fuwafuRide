using UnityEngine;
using System.Collections;

public class upmove : MonoBehaviour {
	
	private float dist;
	public static float lastDist;
	public GameObject rival;
	public GameObject DamageEffect;
	public GameObject MeteoEffect;
	public GameObject ItemEffect;
	public GameObject CloudEffect;
	private GameObject player;
	public GameObject Cplayer;
	private GameObject enemy;
	public GameObject bullet;
	private GameObject Obj;
	private GameObject[] meteos;
	private GameObject tower;

	public bool One = false;
	public  float Bspeed = 4.0f;
	private float StartRot;
	private float S = 0.15f;
	private int count = 1;

	//主に２つの風船と、カメラの親の空のオブジェクトと、画面から出したくない何かのオブジェクトにつけている
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("enemy");

		meteos = GameObject.FindGameObjectsWithTag ("meteo");


		//キャラクターが使う弾の大きさをここで初期化
		bullet.transform.localScale = new Vector3 (S, S, S);
		//キャラクターの初期の回転軸を登録
		StartRot = transform.rotation.y;
	}
	

	void Update () {


		//キャラクターを主に風船やカメラ等のオブジェクトの上への移動
		transform.Translate(Vector3.up * Time.deltaTime*Bspeed);

		dist = enemy.transform.position.y - player.transform.position.y;

		//速度が負になり下に移動するのを防ぐ
		if (Bspeed <= 0) {
			Bspeed = 0.5f;
		}

		float C = transform.localScale.magnitude;
		if (C <= 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		}




		//PV製作時にアニメーション等のカットに切り替えれるためのボタン（ゲームそのものには必要ないのでカット）
//		if(Input.GetKeyDown(KeyCode.Z)){
//			Application.LoadLevel("play");
//		}else if(Input.GetKeyDown(KeyCode.A)){
//			Application.LoadLevel("stage");
//		}else if(Input.GetKeyDown(KeyCode.S)){
//			Application.LoadLevel("camera");
//		}else if(Input.GetKeyDown(KeyCode.X)){
//			Application.LoadLevel("camera(space)");
//		}else if(Input.GetKeyDown(KeyCode.C)){
//			Application.LoadLevel("Story");
//		}else if(Input.GetKeyDown(KeyCode.D)){
//			Application.LoadLevel("last(space)");
//		}

	}

	void OnTriggerEnter (Collider hit)
	{
		//主に２つの風船が何かに当たった場合を書いている

		//風船を獲得した場合＋０．３
		if (hit.CompareTag ("balloon")) {

			Bspeed += 0.7f;
            transform.localScale += Vector3.one;
			Obj = Instantiate (ItemEffect, gameObject.transform.position, Quaternion.identity);


			Obj.transform.parent = gameObject.transform;

		}
		//雲に当って一時的に速減少
		if (hit.CompareTag ("cloud")) {
			CloudEffect.SetActive (true);

			Bspeed -= 3.5f;
		} else {
			CloudEffect.SetActive (false);
		}



		if (hit.CompareTag ("Invisible")) {

			Bspeed += 1.5f;
			Cplayer.GetComponent<invisible> ().enabled = true;
			Invoke ("Speed1", 7.0f);
			player.layer = LayerMask.NameToLayer ("Invisible");
		}

		if (hit.CompareTag ("meteo")) {

			Bspeed -= 2.5f;
			Invoke ("Speed", 0.5f);
			MeteoEffect.SetActive (true);
		}

		if (hit.CompareTag ("power")) {

			bullet.transform.localScale += new Vector3 (1, 1, 1);
			Invoke ("Reset", 6.0f);
		}

		if (hit.CompareTag ("ballet")) {

		//弾が当たる瞬間−１減少とその１．５秒後＋１速度が戻る
		 Bspeed -= 2.8f;
			Invoke ("Speed", 1.5f);
			transform.localScale -= new Vector3 (1, 1, 1);

			DamageEffect.SetActive (true);
			FindObjectOfType<countText> ().AddPoint (count);

		}if(hit.CompareTag("Next")){

			foreach (GameObject meteo in meteos) {
				meteo.GetComponent<meteo> ().enabled = true;
			}
		}
		if(hit.CompareTag("New")){

			if (One == false) {
				One = true;
				lastDist = dist;
				rival.GetComponent<upmove> ().One = true;
			}
				

		}
	}


	void  OnTriggerExit(Collider hit){
		if (hit.CompareTag ("cloud")) {
			Bspeed += 3.5f;
			CloudEffect.SetActive (false);

		}


	}


	void Speed(){
		Bspeed += 2.0f;
		DamageEffect.SetActive (false);
		transform.rotation = Quaternion.Euler (0, StartRot, 0);
		MeteoEffect.SetActive (false);
	}


	void Speed1(){
		Bspeed -= 1.5f;
	}

	void Reset(){
		bullet.transform.localScale = new Vector3 (S, S, S);
	}




}
