using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 inOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + player.TransformDirection(inOffset);
    }
}
