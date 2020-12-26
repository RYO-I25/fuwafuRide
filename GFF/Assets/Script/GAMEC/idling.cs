using UnityEngine;
using System.Collections;

public class idling : MonoBehaviour {

	public float amplitude = 0.01f; // 振幅
	private int frameCnt = 0; // フレームカウント
//	private float time;
//	private GameObject kinoko;
//	private GameObject kaeru;

	void Start(){
//		time = 0;
//		kinoko  = GameObject.FindGameObjectWithTag("Player");
//		kaeru  = GameObject.FindGameObjectWithTag("enemy");
	}

	void Update(){
//		time += Time.deltaTime;
//
//		if (time >= 5.2f && time <= 5.6f) {
//			kaeru.transform.Rotate(0, -1.8f, 0);
//		}
//
//		if (time >= 5.6f && time <= 6.8f) {
//			kinoko.transform.Translate (Vector3.right * Time.deltaTime*2);
//		}
//		if (time >= 6.5f && time <= 7.8f) {
//			kaeru.transform.Translate (Vector3.back * Time.deltaTime);
//		}
//		if (time >= 7.4f && time <= 7.8f) {
//			kinoko.transform.Rotate(0, -1.8f, 0);
//		}

	}


	void FixedUpdate () {
		frameCnt += 1;
		if( 10000 <= frameCnt ){
			frameCnt = 0;
		}
		if( 0 == frameCnt%2 ){
			// 上下に振動させる（ふわふわを表現）
			float posYSin = Mathf.Sin(2.0f*Mathf.PI*(float)(frameCnt%200)/(200.0f-1.0f));
			iTween.MoveAdd(gameObject,new Vector3(0, amplitude * posYSin, 0),0.0f);
		}
	}

}