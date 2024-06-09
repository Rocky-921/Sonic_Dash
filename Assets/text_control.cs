using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class text_control : MonoBehaviour
{
    public GameObject ui_enter;
    bool inside=false;
    public GameObject Pause;
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Return)){
            ui_enter.SetActive(false);
            inside=true;
        }
        if(inside && Input.GetKey(KeyCode.Escape)){
            Pause.SetActive(true);
            Time.timeScale=0.0f;
        }
    }
    public void Resume(){
        Pause.SetActive(false);
        Time.timeScale=1.0f;
    }
}
