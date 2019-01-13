using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void StartButton()
    {
        Indestructable.instance.prevScene = SceneManager.GetActiveScene().buildIndex;
        
        //Loads scene
        SceneManager.LoadScene(6);
         
    }

    public void QuitButton() {
        //Quits Game

    }

    public void LevelButton1()
    {

        //Loads scene
        SceneManager.LoadScene(1);

    }

    public void trans1button()
    {

        //Loads scene
        SceneManager.LoadScene(2);

    }

    public void LevelSelectButton()
    {
        SceneManager.LoadScene(4);
    }

    public void Level2Button()
    {
        SceneManager.LoadScene(3);
    }

    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TestButton1()
    {
        SceneManager.LoadScene(5);
    }

    public void EndButton()
    {
        SceneManager.LoadScene(5);

    }

}
