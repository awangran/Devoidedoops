using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    public bool isSword = false;
    private bool attackBlocked = false;
    public float delay = 0.3f;
    public Animator weaponAnimator;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInChildren<Animator>().SetFloat("isSword", isSword?1:0);
    }
    public void attack() {
        if (attackBlocked)
            return;
        weaponAnimator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(delayAttack());
    }
    IEnumerator delayAttack() {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
    public void changeSide(float x) {
        Vector2 scale = transform.localScale;
        if (x < 0) {
            scale.x = -1;
        } else {
            scale.x = 1;
        }
        transform.localScale = scale;
    }
}
