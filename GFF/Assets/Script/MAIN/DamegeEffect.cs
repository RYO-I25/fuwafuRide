using UnityEngine;
using System.Collections;

public class DamegeEffect : MonoBehaviour {

	public GameObject player;
	private Vector4 StartPos;

	// Use this for initialization
	void Start () {


		StartPos = transform.eulerAngles; 



	}

	// Update is called once per frame
	void Update () {



		transform.eulerAngles = StartPos;
		player.transform.eulerAngles +=new Vector3(0,10,0);
	}
}
