using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sword : Enemy
{
    //검을 쓰는 적의 스크립트이다.
    public GameObject sword;
    public float attackAngle=40f;
    public float attackAngleZ_Min = 240f;
    public float attackAngleZ_Max = 320f;

    private Vector3 originalRotate;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        originalRotate=sword.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("sword.transform.localEulerAngles.z : " + sword.transform.localEulerAngles.z);
    }

    public override IEnumerator State_Attack()
    {
        bool swordup = false;
        state = State.ATTACK;

        while (state == State.ATTACK)
        {
            if(swordup == true)
            {
                if(sword.transform.localEulerAngles.z >= attackAngleZ_Max - 2)
                {
                    swordup = false;
                }
                else
                {
                sword.transform.localEulerAngles += new Vector3(0, 0, attackAngle * Time.deltaTime);
                }
            }
            else
            {
                if (sword.transform.localEulerAngles.z <= attackAngleZ_Min)
                {
                    swordup = true;
                }
                else
                {
                    sword.transform.localEulerAngles -= new Vector3(0, 0, attackAngle * Time.deltaTime);
                }
            }
            //Debug.Log(Time.realtimeSinceStartup + " || " + "현재 ATTACK상태");
            yield return null;
        }
        sword.transform.localEulerAngles = originalRotate;

        yield break;
    }
}
