using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttackBehavior : MonoBehaviour
{
    public int damage;
    void Start()
    {
        StartCoroutine(attack());
    }
    IEnumerator attack() {
        yield return new WaitForSeconds(1.1f);
        foreach (Collider2D i in Physics2D.OverlapCircleAll(gameObject.transform.position, gameObject.GetComponent<CircleCollider2D>().radius)) {
            if (i.gameObject.name == "Player")
                i.gameObject.SendMessage("hitPlayer", 10);
        }
        yield return new WaitForSeconds(1.15f);
        Destroy(gameObject);
    }
}
