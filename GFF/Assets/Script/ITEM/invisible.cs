using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour {

	private Renderer _renderer;
	private float R;
	private float G;
	private bool ON = true;
	public GameObject player;


	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
		_renderer.material.EnableKeyword("_EMISSION"); 
		_renderer.material.SetColor("_EmissionColor",new Color(0,0,0));
	}
	
	// Update is called once per frame
	void Update () {

		Invoke ("Stop", 7.0f);

		if (ON == true) {
			R += 0.05f;
			G += 0.05f;	
		} else if (ON == false) {
			R -= 0.05f;
			G -= 0.05f;	
		}


		
		_renderer.material.EnableKeyword("_EMISSION"); 
		_renderer.material.SetColor("_EmissionColor",new Color(R,G,0));

		if(R <= 0.1f ){
			ON = true;
		}else if(R >= 1 ){
			ON = false;
		}
	}


	void Stop(){
		R = 0;
		G = 0;
		Invoke ("Stop1", 0.3f);
		player.layer = LayerMask.NameToLayer ("player");
	}

	void Stop1(){
		gameObject.GetComponent<invisible> ().enabled = false;
	}

}
