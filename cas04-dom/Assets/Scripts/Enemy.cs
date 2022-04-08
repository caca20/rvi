using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public float moveSpeed = 1;
    private int id;
    public void SetId(int _id){
        id=_id;
    }
    public int ID{get {return id;}}

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetHealth(100);
    }
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
}
