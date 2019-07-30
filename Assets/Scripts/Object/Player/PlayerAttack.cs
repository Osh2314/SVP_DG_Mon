using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject stonePrefab;
    [Header("발사체를 스폰할 곳의 X좌표 - PlayerX좌표")]
    public float stonePrefab_SpownX;
    [Header("발사체를 스폰할 곳의 Y좌표 - PlayerY좌표")]
    public float stonePrefab_SpownY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 point = new Vector3();
            Vector2 targetFollowDir;
            GameObject createdObject;
            Rigidbody2D createdRigid;
            point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

           // Debug.Log(mousePos + " || " + point);
            if (transform.position.x - point.x >= 0)
                createdObject = Instantiate(stonePrefab, new Vector3(transform.position.x - stonePrefab_SpownX, transform.position.y + stonePrefab_SpownY, 0), Quaternion.identity);
            else
                createdObject = Instantiate(stonePrefab, new Vector3(transform.position.x + stonePrefab_SpownX, transform.position.y + stonePrefab_SpownY, 0), Quaternion.identity);

            createdRigid = createdObject.GetComponent<Rigidbody2D>();
            targetFollowDir = point - createdObject.transform.position;
            targetFollowDir.Normalize();

            createdRigid.AddForce(targetFollowDir * 1000);
        }
    }
}