using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Weapons weapon;
    [SerializeField] Camera cam;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;


    private float horizontal;
    private float vertical;

    
    private void Update()
    {
        GetInput();
     //   FixedUpdate();
        RotateCharacter();

        if(Input.GetMouseButton(0))
        {
            if(weapon != null)
            {
                weapon.Shoot();
            }
        }
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 changeInPosition = new Vector3(-horizontal, 0f, -vertical);
        Vector3 goToPositon = transform.position + changeInPosition * speed * Time.deltaTime;   
        rigidBody.MovePosition(goToPositon);
    }

    private void RotateCharacter()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}