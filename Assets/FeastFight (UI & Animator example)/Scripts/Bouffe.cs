using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouffe : MonoBehaviour
{
    public BouffeData data;
	public Image scoreUp1;
	public Image scoreUp2;
	public Image scoreUp3;
	public Image scoreUp4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag == "Player1"){
			scoreUp1.enabled = true;
			PlayerManager.instance.score1 += data.score;
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Player2"){
			scoreUp2.enabled = true;
			PlayerManager.instance.score2 += data.score;
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Player3"){
			scoreUp3.enabled = true;
			PlayerManager.instance.score3 += data.score;
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Player4"){
		    scoreUp4.enabled = true;
			PlayerManager.instance.score4 += data.score;
			Destroy(gameObject);
		}
	}
}
