using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour {
    public float speed = 3.0f;
    private Vector3 last;
    public Animator animatorController;
    private void Start() {
        animatorController = GetComponent<Animator>();
    }
     void Update () {
         Vector3 pos = Vector3.zero;
 
         if (Input.GetKey ("w")) {
             pos.y += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.y -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
         }
         transform.parent.position += pos;
         updateAnimation(pos);
         last = Vector3.Normalize(pos);
     }
     public void updateAnimation(Vector3 pos) {
        if (pos == Vector3.zero) {
            animatorController.SetFloat("XInput", last.x);
            animatorController.SetFloat("YInput", last.y);
            animatorController.SetBool("Moving", false);
            animatorController.CrossFade("Idle", 0);
        } else {
            animatorController.SetFloat("XInput", pos.x);
            animatorController.SetFloat("YInput", pos.y);
            animatorController.SetBool("Moving", true);
            animatorController.CrossFade("Movement", 0);
        }
     }

}
