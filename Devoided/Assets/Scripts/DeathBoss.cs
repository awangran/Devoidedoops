using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoss : MonoBehaviour
{
    private int health = int.MaxValue;
    public Player player;
    public DeathAttackBehavior projectilePrefab;
    public float delay = 4;
    private bool canAttack = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            StartCoroutine(death());
        }
        if (canAttack) {
            StartCoroutine(AttackAfterTime(delay));
        }
    }
    void Attack() {
        canAttack = true;
        Instantiate(projectilePrefab, player.gameObject.transform.position, transform.rotation);
        gameObject.GetComponent<Animator>().ResetTrigger("Attack");
    }
     IEnumerator AttackAfterTime(float time) {
        Debug.Log("deathAttak");
     canAttack = false;
     yield return new WaitForSeconds(time);
    gameObject.GetComponent<Animator>().SetTrigger("Attack");
 }
 void takeDamage(int damage) {
    health -= damage;
 StartCoroutine(flashColor(new Color(1, 0, 0, 0.7f)));
    }
    IEnumerator flashColor(Color color) {
        gameObject.GetComponent<SpriteRenderer>().material.color = color;
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
    }
 IEnumerator death() {
    gameObject.GetComponent<Animator>().Play("Death");
    yield return new WaitForSeconds(4);
    Destroy(gameObject);
 }
}
