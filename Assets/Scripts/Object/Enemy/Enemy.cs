using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;

    public enum State { IDLE, MOVE, STUN, ATTACK, DEAD};
    public State state = State.IDLE;

    private Rigidbody2D rigid;
    private bool isSeeRight = true;
    
    // Start is called before the first frame update
    protected void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(State_Idle());
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public IEnumerator State_Idle() {
        state = State.IDLE;

        //ThisAnimator.SetTrigger((int)State.IDLE);

        while (state == State.IDLE) {
            //플레이어
            if (GameManager.Instance.isGamePlaying == true) {
                StartCoroutine(State_Move());
                yield break;
            }
            //Debug.Log(Time.realtimeSinceStartup + " || " + "현재 IDLE상태");
            yield return null;
        }
        yield break;
    }

    public IEnumerator State_Move()
    {
        state = State.MOVE;

        //ThisAnimator.SetTrigger((int)State.IDLE);

        while (state == State.MOVE)
        {
            //플레이어
            if (GameManager.Instance.isGamePlaying == true)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                //if()
            }
         //   Debug.Log(Time.realtimeSinceStartup + " || " + "현재 MOVE상태");
            yield return null;
        }
        yield break;
    }

    public virtual IEnumerator State_Attack()
    {
        yield break;
    }

}
