using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
    private GameObject speechBubble;
    private CircleCollider2D speechCollider;
    void Start()
    {   
        speechBubble = GameObject.Find(gameObject.name + "/SpeechBubble");
        speechBubble.SetActive(false);
        speechCollider = gameObject.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (speechCollider.IsTouching(player.GetComponent<PolygonCollider2D>())) {
            speechBubble.SetActive(true);
        } else {
            speechBubble.SetActive(false);
        }
    }
}
