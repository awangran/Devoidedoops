using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmperorBoss : MonoBehaviour
{   
    private int health = 100;
    public GameObject player;
    public ProjectileBehavior projectilePrefab;
    public Transform launchOffset;
    public float delay = 4;
    private bool canAttack = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //collision detection like if hit then change boss bar

        //also attack
        if (canAttack) {
            StartCoroutine(AttackAfterTime(delay));
        }
    }
    void Attack() {
        canAttack = true;
        Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
        gameObject.GetComponent<Animator>().ResetTrigger("Attack");
    }
     IEnumerator AttackAfterTime(float time) {
     canAttack = false;
     yield return new WaitForSeconds(time);
    gameObject.GetComponent<Animator>().SetTrigger("Attack");
 }
}
