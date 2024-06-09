using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    string parentname;
    bool todestroy=false;
    void Start()
    {
        parentname=transform.name;
        if(parentname == "Section(Clone)") todestroy=true;
    }
    void FixedUpdate(){
        if(todestroy){
            if(Player_Moves.distance>=transform.position.z+60f){
                Destroy(gameObject);
            }
        }
    }
    
}
