using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {

        //Defines what objects incur a trigger, based on name of the gameObject
        if (col.gameObject.name == "car")
        {
            SceneManager.LoadScene("level1");
            //Prints to Console
            Debug.Log("Test");
        }

        if (col.gameObject.name == "LevelChangeTrigger")
        {
            SceneManager.LoadScene("levelbetween1");
            Debug.Log("Test2");
        }

        
        if (col.gameObject.name == "police")
        {
            SceneManager.LoadScene(3);
            Debug.Log("Test3");
        }
        

        if (col.gameObject.name == "ChangeLevelTrigger")
        {
            SceneManager.LoadScene(6);
            Debug.Log("Test4");
        }


    }

 

}
