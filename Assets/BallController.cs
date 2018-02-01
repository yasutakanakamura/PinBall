using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるZ軸の最大値
	private float visiblePozZ = -6.5f;

	//ゲームオーバーを表示するテキスト
	private GameObject gameOverText;

	//得点を表示するテキスト
	private GameObject scoreText;

	//得点
	private int score = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameOverText = GameObject.Find("GameOverText");

		//シーン中のscoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
		
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外にでた場合
		if (this.transform.position.z < this.visiblePozZ) {
			//GameoverTextにゲームオーバーを表示
			this.gameOverText.GetComponent<Text> ().text = "Game Over";
		}

	}
	void OnCollisionEnter (Collision other) {

		//小さい星に衝突した場合
		if (other.gameObject.tag == "SmallStarTag") {
			this.score += 10;
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		}
		//大きい星に衝突した場合
		if (other.gameObject.tag == "LargeStarTag") {
			this.score += 20;
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		}
		//小さい雲に衝突した場合
		if (other.gameObject.tag == "SmallCloudTag") {
			this.score += 30;
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		}
		//大きい雲に衝突した場合
		if (other.gameObject.tag == "LargeCloudTag") {
			this.score += 40;
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
		}
	}
}
