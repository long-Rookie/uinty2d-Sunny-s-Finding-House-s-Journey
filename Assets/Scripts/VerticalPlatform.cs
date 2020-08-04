﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float speed = 20f;

    public float changeDirectionTime = 2f;//改变方向的时间
    public float changeTimer;

    Rigidbody2D rbody;
    private Vector2 moveDirection;
    Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        position = rbody.position;
        changeTimer = changeDirectionTime;
        moveDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {

        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;

        rbody.MovePosition(position);

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            rbody.AddForce(new Vector2(0, 60));
        }
    }


}
