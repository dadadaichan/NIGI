using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatRotateType : MonoBehaviour
{
    public float moveSpeed, ms =　0.5f;
    public float angle = 30f;
    public float turnSpeed = 90;
    public float speedUpValue = 1.5f;
    public float speedDownValue = 0.02f;

    private bool isTurning = false;
    private float endRT;
    private bool isSpeedUp = false;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 forward = transform.up;
        rb.MovePosition(rb.position + forward * moveSpeed * Time.fixedDeltaTime);
        //↑オブジェクトを「現在位置から相対的に」動かす
    }
    void Update()
    {
        //this.gameObject.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.Self);//オブジェクトを「現在位置から相対的に」動かす関数
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!isTurning)
            {
                isTurning = true;
                endRT = this.transform.eulerAngles.z - angle;
            }
            isSpeedUp = true;
            moveSpeed = speedUpValue;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!isTurning)
            {
                isTurning = true;
                endRT = this.transform.eulerAngles.z + angle;
            }
            isSpeedUp = true;
            moveSpeed = speedUpValue;
        }

        if (isTurning)
        {
            float newAngle = Mathf.MoveTowardsAngle(this.transform.eulerAngles.z, endRT, turnSpeed * Time.deltaTime);
            //この引数の三つめは1フレームで動ける最大の角度が入る。turnSpeed * Time.deltaTimeで1フレームあたりに動く角度が出る。
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,newAngle);//newAngleにはstartRT+1フレームで動いた角度、が入ってる。

            if (Mathf.Approximately(newAngle,endRT))
            {
                isTurning = false;
            }
        }

        if (isSpeedUp)
        {
            moveSpeed -= speedDownValue;
            if(moveSpeed <= ms)
            {
                moveSpeed = ms;
                isSpeedUp = false;
            }
        }
    }
}

