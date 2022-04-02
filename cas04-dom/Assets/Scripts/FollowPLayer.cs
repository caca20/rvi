using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
     public Transform player;

    void Update () {
        transform.position = player.transform.position + new Vector3(1, 8, 30);
    }
}
