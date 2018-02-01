using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);

		
	}
	
	// Update is called once per frame
	void Update () {
		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}

		//右矢印キーお押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キーが離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
		
		
		//画面解像度の取得
		int ScreenSizeW = Screen.width;
		int HalfScreenSizeW = ScreenSizeW/2;
		//パターン1
		//PhoneXで画面の左側でタップした時、左フリッパーを動かす
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			//タッチ座標を取得
			Vector2 touchPos = Input.GetTouch(0).position;
			Debug.Log(touchPos);
				//画面左側をタッチした時にフリッパーを上げる
				if(touchPos.x <= HalfScreenSizeW && tag == "LeftFripperTag"){
					SetAngle (this.flickAngle);
				}
				//
		}
		//iPhoneXで画面の右側でタップした時、右フリッパーを動かす
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			//タッチ座標を取得
			Vector2 touchPos = Input.GetTouch(0).position;
			Debug.Log(touchPos);
				//画面右側をタッチした時にフリッパーを上げる
				if(touchPos.x >= HalfScreenSizeW && tag == "RightFripperTag"){
					SetAngle (this.flickAngle);
				}
		}
		//左タッチを離した時
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
			if (tag == "LeftFripperTag"){
				SetAngle (this.defaultAngle);
			}
		}

		//右タッチを離した時
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
			if (tag == "RightFripperTag"){
				SetAngle (this.defaultAngle);
			}
		}
		
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}

}
