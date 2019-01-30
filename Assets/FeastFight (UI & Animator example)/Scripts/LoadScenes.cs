using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {

	public static LoadScenes loadInstance = null;
	
 	void Awake()
    {
        if (loadInstance == null)
        {
            loadInstance = this;
        }
        else if (loadInstance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }
	public void Load (int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
	
}
