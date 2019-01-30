using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText1;
	public Text scoreText2;
	public Text scoreText3;
	public Text scoreText4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText1.text = PlayerManager.instance.score1.ToString();
		scoreText2.text = PlayerManager.instance.score2.ToString();
		scoreText3.text = PlayerManager.instance.score3.ToString();
		scoreText4.text = PlayerManager.instance.score4.ToString();
	}
}
