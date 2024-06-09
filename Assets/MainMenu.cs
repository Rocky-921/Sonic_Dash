using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void playing(){
        CoinCollector.count=0;
        Player_Moves.go=false;
        Player_Moves.inside=0;
        Time.timeScale=1.0f;
        SceneManager.LoadSceneAsync(1);
    }
    public void quitting(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
