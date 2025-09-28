using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatRotateType : MonoBehaviour
{
    public float moveSpeed, ms =�@0.5f;
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
        //���I�u�W�F�N�g���u���݈ʒu���瑊�ΓI�Ɂv������
    }
    void Update()
    {
        //this.gameObject.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.Self);//�I�u�W�F�N�g���u���݈ʒu���瑊�ΓI�Ɂv�������֐�
        
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
            //���̈����̎O�߂�1�t���[���œ�����ő�̊p�x������BturnSpeed * Time.deltaTime��1�t���[��������ɓ����p�x���o��B
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,newAngle);//newAngle�ɂ�startRT+1�t���[���œ������p�x�A�������Ă�B

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

