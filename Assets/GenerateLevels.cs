using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] sections;
    int zpos=100;
    public bool createsec=false;
    int secnum;

    void FixedUpdate()
    {
        if(!createsec && Player_Moves.go){
            createsec=true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection(){
        secnum=Random.Range(0,sections.Length);
        Instantiate(sections[secnum],new Vector3(0,0,zpos),Quaternion.identity);
        zpos+=50;
        yield return new WaitForSeconds(4);
        createsec=false;
    }
}
