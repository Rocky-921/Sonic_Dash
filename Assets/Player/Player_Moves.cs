using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Player_Moves : MonoBehaviour
{    
    public TextMeshProUGUI dist;
    public Slider slider;
    public Animator animator;
    public Vector3 for_speed;
    public Vector3 right_speed;
    public Vector3 left_speed;
    bool right=false;
    float right_inc=0.0f;
    bool left=false;
    float left_inc=0.0f;
    public static bool go=false;
    public static bool dash=false;
    public static float distance=0.0f;
    float velocity_hash;
    public static int inside=0;
    void start(){
        animator=GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        distance=transform.position.z;
        dist.text = "SCORE: " + transform.position.z.ToString("0");
        if(!go && inside==0){
            go = Input.GetKey(KeyCode.Return);
            animator.SetBool("idle",true);
            animator.SetBool("run",false);
        }
        if(go){
            if(inside==0) inside++;
            animator.SetBool("idle",false);
            if(!dash) animator.SetBool("run",true);
            animator.SetBool("jump",false);
            animator.SetBool("roll",false);

            if(!dash){
                slider.value += for_speed.z;
                transform.position += for_speed;
            }

            if(!right) right=Input.GetKey(KeyCode.RightArrow);
            if(right && !left){
                if(transform.position.x<2.5f && right_inc<2.5f){
                    right_inc+=0.1f;
                    transform.position += right_speed;
                }else{
                    right=false;
                    right_inc=0.0f;
                }
            }else{
                if(!left) left=Input.GetKey(KeyCode.LeftArrow);
                if(left){
                    if(transform.position.x>-2.5f && left_inc<2.5f){
                    left_inc+=0.1f;
                    transform.position -= left_speed;
                    }else{
                        left=false;
                        left_inc=0.0f;
                    }
                }
            }

            bool jump=Input.GetKey(KeyCode.UpArrow);
            if(jump){

                CharacterController temp = this.GetComponent<CharacterController>();
                temp.center = new Vector3(temp.center.x,1.9f,temp.center.z);
                animator.SetBool("jump",true);
                StartCoroutine(action());
            }

            bool roll=Input.GetKey(KeyCode.DownArrow);
            if(roll){
                CharacterController temp = this.GetComponent<CharacterController>();
                temp.center = new Vector3(temp.center.x,0.45f,temp.center.z);
                animator.SetBool("roll",true);
                StartCoroutine(action());
            }

            if(!dash && slider.value==100) dash=Input.GetKey(KeyCode.Space);
            if(dash){
                animator.SetBool("dash",true);
                animator.SetBool("run",false);
                velocity_hash=Animator.StringToHash("velocity");
                if(for_speed.z < 0.25f){
                    velocity_hash += 0.01f;
                    for_speed.z += 0.01f;
                }
                transform.position+=for_speed;
                slider.value-=for_speed.z;
                if(slider.value==0){
                    dash=false;
                    velocity_hash=0.15f;
                    for_speed.z=0.1f;
                    animator.SetBool("dash",false);
                    animator.SetBool("run",true);
                }
            }
        }
    }
    IEnumerator action(){
        yield return new WaitForSeconds(1);
        CharacterController temp = this.GetComponent<CharacterController>();
        temp.center = new Vector3(temp.center.x,0.9f,temp.center.z);
    }
}