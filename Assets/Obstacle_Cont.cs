using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstacle_Cont : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    bool isfall=false;
    float back=0f;
    void FixedUpdate(){
        if(isfall){
            if(back<2f){
                cam.transform.position -= new Vector3(0,0,0.1f);
                back+=0.1f;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(Player_Moves.dash) return; 
        Player_Moves.go=false;
        isfall = true;
        player.GetComponent<Animator>().Play("Falling");
        StartCoroutine(Menu());
    }
    IEnumerator Menu(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
