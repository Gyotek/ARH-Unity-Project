using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private bool direction;
	private bool throwed;
	private FirstController CharacterScript;

	
	public FixedJoint2D FixedJoint2D;
	public Rigidbody2D Rigidbody;
	public Transform Transform;
	public CircleCollider2D Collider;
	public GameObject Character;
	

	[SerializeField]
	private float speed = 10;

	// Use this for initialization

	private void Awake() {
	CharacterScript = Character.GetComponent<FirstController>();	
	}
	void Start () {
		/*direction = (Random.Range(0, 2) == 0); //false = left, true = right
		if(direction == true){
			Debug.Log("Let's go to the right !");
		} else{
			Debug.Log("Let's go to the left !");
		}*/
	}
	
	
	// Update is called once per frame
	void Update () {
		//RollingBall();
		if (Input.GetKeyDown("r") && FixedJoint2D.enabled == true){
			Throwing();
		}
		if (throwed == true && Transform.position.x >= FixedJoint2D.connectedAnchor.x + Transform.position.x){
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		else if (throwed == true && Transform.position.x >= FixedJoint2D.connectedAnchor.x + Transform.position.x +2f){
			throwed = false;
		}
	}


	void Throwing(){
		throwed = true;
		Debug.Log("Throwing");
		FixedJoint2D.enabled = false;
		StartCoroutine(ThrowingCoroutine());
	}

	IEnumerator ThrowingCoroutine(){
		if (CharacterScript.bFacingRight)
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		yield return new WaitForSeconds(0.2f);
		Debug.Log("Coroutine ended");
		Collider.enabled = true;

	}

	void RollingBall(){  
		if (direction == false){
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		else if (direction == true){
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			//Destroy(gameObject);
			Debug.Log("I touched it ! :o");
			 if (FixedJoint2D.enabled == false){
				FixedJoint2D.enabled = true; 
				Collider.enabled = false;
			}
		}
		/*else if (collision.gameObject.tag == "Object") {
			if (direction == false){
				direction = true;
				Debug.Log("Direction Changed !");
			}
			else if (direction == true){
				direction = false;
				Debug.Log("Direction Changed !");
			}

		}*/
			
	}
}
