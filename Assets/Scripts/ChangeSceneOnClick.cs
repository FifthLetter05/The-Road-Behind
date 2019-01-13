using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
	        Indestructable.instance.prevScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
            Debug.Log("Key!");
        }
	}
}
