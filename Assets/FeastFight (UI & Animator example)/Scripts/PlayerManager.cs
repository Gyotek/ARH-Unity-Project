using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerManager : MonoBehaviour {

    public List<PlayerIndex> playersIndexList = new List<PlayerIndex> { (PlayerIndex)0, (PlayerIndex)1, (PlayerIndex)2, (PlayerIndex)3 };

    public float speed;
    public float rotateSpeed;
    public float acceleration;

    public int score1;
    public int score2;
    public int score3;
    public int score4;

    public static PlayerManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
