using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float origin_JumpForce;

    public enum STATE { IDLE, MOVE, INSTALLMODE, STOP, ATTACK, DEAD };
    public STATE state = STATE.IDLE;

    private bool isSeeRight = true;
    private float jumpForce;
    private bool cMove = true;
    public bool cJump = true;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(STATE_IDLE());
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (cMove == false)
            return;
        transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
        //transform.Translate(h * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && cJump == true)
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            cJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(STATE_INSTELLMODE());
        if (state == STATE.INSTALLMODE)
        {
            //Instantiate(new GameObject, )
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

            }
        }
        if (h >0) // 1이 오른쪽 -1이 왼쪽
        {
            isSeeRight = true;
            transform.localEulerAngles = new Vector3(0, 180, 0);
           // transform.Rotate(new Vector3(0, 0, 0));
        }
        if(h<0)
        {
            isSeeRight = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            //transform.Rotate(new Vector3(0, 180, 0));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            cJump = true;
            jumpForce = origin_JumpForce;
        }
        if (collision.gameObject.tag == "Floor")
        {
            cJump = true;
            jumpForce = origin_JumpForce * 2;
        }
    }

    public bool GetDirection() // Direction == 방향
    {
        return isSeeRight;
    }

    IEnumerator STATE_IDLE()
    {
        state = STATE.IDLE;

        //ThisAnimator.SetTrigger((int)State.IDLE);

        while (state == STATE.IDLE)
        {
            //플레이어
            if (GameManager.Instance.isGamePlaying == true)
            {
                StartCoroutine(STATE_MOVE());
                yield break;
            }
            //Debug.Log(Time.realtimeSinceStartup + " || " + "현재 IDLE상태");
            yield return null;
        }
        yield break;
    }

    IEnumerator STATE_MOVE()
    {
        state = STATE.MOVE;
        //ThisAnimator.SetTrigger((int)State.IDLE);

        while (state == STATE.MOVE)
        {
            //플레이어
            if (GameManager.Instance.isGamePlaying == true)
            {

            }
            //   Debug.Log(Time.realtimeSinceStartup + " || " + "현재 MOVE상태");
            yield return null;
        }
        yield break;
    }

    IEnumerator STATE_INSTELLMODE()
    {
        state = STATE.INSTALLMODE;
        //ThisAnimator.SetTrigger((int)State.IDLE);

        while (state == STATE.INSTALLMODE)
        {
            //플레이어
            if (GameManager.Instance.isGamePlaying == true)
            {

            }
            //   Debug.Log(Time.realtimeSinceStartup + " || " + "현재 MOVE상태");
            yield return null;
        }
        yield break;
    }
}
