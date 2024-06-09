using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coin_script : MonoBehaviour
{
    public AudioSource coin_sound;
    int rot_speed=5;
    void FixedUpdate()
    {
        transform.Rotate(0,rot_speed,0,Space.World);
    }
    void OnTriggerEnter(Collider other){
        coin_sound.Play();
        CoinCollector.count++;
        this.gameObject.SetActive(false);
    }
}
