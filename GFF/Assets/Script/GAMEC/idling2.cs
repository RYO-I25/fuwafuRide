﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idling2 : MonoBehaviour {

	private Vector3 StartPos;
	private Vector3 EndPos;
	public float time;
	private Vector3 deltaPos;
	private float elapsedTime;
	private bool bStartToEnd = true;
	void Start () {
		// StartPosをオブジェクトに初期位置に設定



		// 1秒当たりの移動量を算出
		deltaPos = (EndPos - StartPos) / time;
		elapsedTime = 0;
	}

	void Update () {

		StartPos = new Vector3(transform.position.x - 0.025f, transform.position.y, transform.position.z);
		EndPos = new Vector3(transform.position.x + 0.025f, transform.position.y, transform.position.z);
		// 1秒当たりの移動量にTime.deltaTimeを掛けると1フレーム当たりの移動量となる
		// Time.deltaTimeは前回Updateが呼ばれてからの経過時間
		transform.position += deltaPos * Time.deltaTime;
		// 往路復路反転用経過時間
		elapsedTime += Time.deltaTime;
		// 移動開始してからの経過時間がtimeを超えると往路復路反転
		if (elapsedTime > time)
		{
			if (bStartToEnd)
			{
				// StartPos→EndPosだったので反転してEndPos→StartPosにする
				// 現在の位置がEndPosなので StartPos - EndPosでEndPos→StartPosの移動量になる
				deltaPos = (StartPos - EndPos) / time;
				// 誤差があるとずれる可能性があるので念のためオブジェクトの位置をEndPosに設定
				transform.position = EndPos;
			}
			else
			{
				// EndPos→StartPosだったので反転してにStartPos→EndPosする
				// 現在の位置がStartPosなので EndPos - StartPosでStartPos→EndPosの移動量になる
				deltaPos = (EndPos - StartPos) / time;
				// 誤差があるとずれる可能性があるので念のためオブジェクトの位置をSrartPosに設定
				transform.position = StartPos;
			}
			// 往路復路のフラグ反転
			bStartToEnd = !bStartToEnd;
			// 往路復路反転用経過時間クリア
			elapsedTime = 0;
		}
	}
}
