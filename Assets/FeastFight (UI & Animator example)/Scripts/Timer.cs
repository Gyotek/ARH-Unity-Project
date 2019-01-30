using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	public float timeLeft = 60;
	public float timeBeforeStart;

	// Use this for initialization
	void Start () {
		timeBeforeStart = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = 60 - Time.realtimeSinceStartup + timeBeforeStart;
		timerText.text = timeLeft.ToString();
		if (timeLeft <= 0f){
			LoadScenes.loadInstance.Load(2);
		}
	}
}
