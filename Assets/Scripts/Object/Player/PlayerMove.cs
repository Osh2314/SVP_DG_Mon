using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float origin_JumpForce;


    private bool isDirRight = true;
    private float jumpForce;
    private bool cMove = true;
    public bool cJump = true;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (cMove == false)
            return;
        transform.Translate(h * speed * Time.deltaTime, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space) && cJump == true)
        {
            rigid.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            cJump = false;
        }

        if(h >= 0) // 1이 왼쪽 0이 오른쪽
        {
            isDirRight = true;
        }
        else
        {
            isDirRight = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
        cJump = true;
            jumpForce = origin_JumpForce;
        }
        if(collision.gameObject.tag == "Floor")
        {
            cJump = true;
            jumpForce = origin_JumpForce * 2;
        }
    }

    public bool GetDirection() // Direction == 방향
    {
        return isDirRight;
    }

}
