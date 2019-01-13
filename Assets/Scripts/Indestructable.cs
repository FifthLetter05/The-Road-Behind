using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indestructable : MonoBehaviour
{
    public static Indestructable instance = null;

    private float timer = 0.0f;
    private GameObject Canvas;
    private GameObject QuitMsg;
    private Text QuitText;
    private string QuitRef = "Quiting";
    private bool quit = false;

    public int prevScene;

    void Awake() {
        // If we don't have an instance set - set it now
        if(!instance )
            instance = this;
        // Otherwise, its a double, we dont need it - destroy
        else {
            Destroy(gameObject) ;
            return;
        }

        //set this object to last through all scenes
        DontDestroyOnLoad(gameObject) ;

        //set scene change callback
        SceneManager.activeSceneChanged += OnSceneChange;
        
    }

    private void CreateQuitObject()
    {
        QuitMsg = new GameObject("Quitting");
        Canvas = GameObject.Find("Canvas");
        QuitMsg.transform.parent = Canvas.transform;
        QuitText = QuitMsg.AddComponent<Text>();
        QuitText.text = QuitRef;
        QuitText.font = Font.CreateDynamicFontFromOSFont("Arial", 14);
        QuitText.fontSize = 50;
        QuitText.color = new Color(1, 1, 1, 0);
        var rect = QuitMsg.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.up;
        rect.anchorMax = Vector2.up;
        var width = 600;
        var height = 100;
        rect.anchoredPosition = new Vector2(width / 2 + 20, -height / 2 - 10);
        rect.sizeDelta = new Vector2(width, height);
    }

    //triggers on scene change
    private void OnSceneChange(Scene current, Scene next)
    {
        CreateQuitObject();
    }

    private void Update()
    {
        #if (UNITY_STANDOLONE)
        if (Input.GetKey(KeyCode.Escape) && !quit)
        {
            //time it takes to quit
            var QuitTime = 1.0f;
            timer += Time.deltaTime;
            
            //set color to fade
            QuitText.color = new Color(1, 1, 1, timer / QuitTime);
            
            //math time: divide time holding Esc by time it takes to quit and multiply by total dots to get number
            //of dots to display
            var dots = "";
            for (float i = 1; i <= timer / QuitTime * 4 ; i++)
            {
                dots += ".";
            }

            QuitText.text = QuitRef + dots;
            if (timer >= QuitTime)
            {
                Application.Quit();
                quit = true;
            }
        }

        //reset stuff if user lets go of Esc
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            timer = 0.0f;
            QuitText.color = new Color(1, 1, 1, 0);
            QuitText.text = QuitRef;
            quit = false;
        }
        #endif
    }
}
