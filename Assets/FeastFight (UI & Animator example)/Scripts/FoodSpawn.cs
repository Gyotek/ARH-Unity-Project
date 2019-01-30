using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSpawn : MonoBehaviour {

	public GameObject CuissePrefab;
	public GameObject BuchePrefab;
	public Image plusCinquante1;
	public Image plusCinquante2;
	public Image plusCinquante3;
	public Image plusCinquante4;
	private bool isDisabling = false;

	Vector3 position;

	// Use this for initialization
	void Start () {		//X -20 à -20, Y 50, Z -50 à 50
		StartCoroutine(Rain(2f));
	}
	
	// Update is called once per frame
	void Update () {
		if (plusCinquante1.enabled == true && isDisabling == false){
			isDisabling = true;
			StartCoroutine (DisabledPlusCinquante1());
		}
		if (plusCinquante2.enabled == true && isDisabling == false){
			isDisabling = true;
			StartCoroutine (DisabledPlusCinquante2());
		}
		if (plusCinquante3.enabled == true && isDisabling == false){
			isDisabling = true;
			StartCoroutine (DisabledPlusCinquante3());
		}
		if (plusCinquante4.enabled == true && isDisabling == false){
			isDisabling = true;
			StartCoroutine (DisabledPlusCinquante4());
		}
	}

	IEnumerator Rain(float RainAgain){
		position = new Vector3 (Random.Range(-20, 20), 100, Random.Range(-50, 50));
		RandomFood();
		yield return new WaitForSeconds(RainAgain);
		StartCoroutine(Rain(Random.Range(0.1f, 2f)));
	}

	void RandomFood() {
		int randomFood = Random.Range(1, 3);
		switch (randomFood) {
		case 1 :
			GameObject CuisseSpawned = Instantiate (CuissePrefab, position, Random.rotation);
			CuisseSpawned.GetComponent<Bouffe>().scoreUp1 = plusCinquante1;
			CuisseSpawned.GetComponent<Bouffe>().scoreUp2 = plusCinquante2;
			CuisseSpawned.GetComponent<Bouffe>().scoreUp3 = plusCinquante3;
			CuisseSpawned.GetComponent<Bouffe>().scoreUp4 = plusCinquante4;
			break;
	
		 case 2 :
			GameObject BucheSpawned = Instantiate (BuchePrefab, position, Random.rotation);
			BucheSpawned.GetComponent<Bouffe>().scoreUp1 = plusCinquante1;
			BucheSpawned.GetComponent<Bouffe>().scoreUp2 = plusCinquante2;
			BucheSpawned.GetComponent<Bouffe>().scoreUp3 = plusCinquante3;
			BucheSpawned.GetComponent<Bouffe>().scoreUp4 = plusCinquante4;
			break;
		}
	}

	IEnumerator DisabledPlusCinquante1(){
		yield return new WaitForSeconds(0.5f);
		plusCinquante1.enabled = false;
		isDisabling = false;
	}
	IEnumerator DisabledPlusCinquante2(){
		yield return new WaitForSeconds(0.5f);
		plusCinquante2.enabled = false;
		isDisabling = false;
	}
	IEnumerator DisabledPlusCinquante3(){
		yield return new WaitForSeconds(0.5f);
		plusCinquante3.enabled = false;
		isDisabling = false;
	}
	IEnumerator DisabledPlusCinquante4(){
		yield return new WaitForSeconds(0.5f);
		plusCinquante4.enabled = false;
		isDisabling = false;
	}

}
	