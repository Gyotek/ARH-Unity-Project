using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimation : MonoBehaviour {

	Animator anim;
	AnimatorStateInfo animStateInfo;
	int walkTreeId = Animator.StringToHash("Base Layer.WalkTree");
	int runTreeId = Animator.StringToHash("Base Layer.RunTree");

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		animStateInfo = anim.GetCurrentAnimatorStateInfo(0);

		float velocity = Input.GetAxis("Vertical");
		float direction = Input.GetAxis("Horizontal");

		if (Input.GetKey(KeyCode.LeftShift)&&velocity >0.7)
			velocity = 0.6f;

		anim.SetFloat("Velocity",velocity);
		anim.SetFloat("Direction",direction);

		if(Input.GetKeyDown(KeyCode.Space) && (animStateInfo.fullPathHash == walkTreeId || animStateInfo.fullPathHash == runTreeId ))
			anim.SetTrigger("Roll");
		else if(Input.GetKeyDown(KeyCode.G) && (animStateInfo.fullPathHash == walkTreeId || animStateInfo.fullPathHash == runTreeId ))
			anim.SetTrigger("Grenade");
	}
}
