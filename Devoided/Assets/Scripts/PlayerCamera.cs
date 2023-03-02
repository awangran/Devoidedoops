using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 cameraPos;
    void Start() {

    }
    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + cameraPos;
    }
}
