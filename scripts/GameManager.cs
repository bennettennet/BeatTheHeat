using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Stores all the text displayed in UI
    public Text text1;
    public Text text2;
    public Text time;
    //allows non static variables to be called
    public static GameManager GM;

    string minutes;
    string seconds;
    string millisecs;

    float theTime;
    //allows to increase the speed of time if needed
    public float speed = 1;
    //time goes up while the player is playin
    public static bool playin = true;

    private void Start()
    {
        //intiating variables
        GM = this;
        text1.text = "";
        text2.text = "";
    }
    void Update()
    {
        //time goes up
        //will to live goes down :)
        if (playin == true)
        {
            theTime += Time.deltaTime * speed;
            minutes = Mathf.Floor((theTime % 360000) / 6000).ToString("00");
            seconds = Mathf.Floor((theTime % 6000) / 100).ToString("00");
            millisecs = (theTime % 99).ToString("00");
            time.text = minutes + ":" + seconds + ":" + millisecs;
        }
            
    }
    //changes the text that wasn't present before to show game over
    public void GameOver()
    {
        Debug.Log("game over");
        text1.text = "GAME OVER";
        text2.text = "PRESS SPACE TO RESTART";


    }
    //stops clock and shows the completed time
    public void Finish()
    {
        playin = false;
        text1.text = "FINISHED";
        text2.text = "Level 1 - "+ minutes + ":" + seconds + ":" + millisecs;
    }

}
