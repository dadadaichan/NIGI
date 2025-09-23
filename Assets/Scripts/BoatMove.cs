using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public Vector3 moveOffset = new Vector3(1f, 0, 0);//�ړ���
    public float moveTime = 1f;//�ړ�����
    private bool isMoving = false;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) && !isMoving)
        {
            StartCoroutine(LerpMove(moveTime,-moveOffset));
        }

        if (Input.GetKeyUp(KeyCode.D) && !isMoving)
        {
            StartCoroutine(LerpMove(moveTime, moveOffset));
        }
    }

    IEnumerator LerpMove(float time, Vector3 offset)
    {
        isMoving = true;
        Vector3 startPos = this.gameObject.transform.position;
        Vector3 endPos = startPos + offset;
        float elapsedTime = 0;//�o�ߎ���
        float p = 0;//0�|1�ŕ\����銄���B���̒l�ɉ�����startPos��endPos�̊Ԃ̐���_�����܂��Ă���B

        while (elapsedTime < time)//1�b�o�߂���܂ŌJ��Ԃ�
        {
            p = Mathf.Clamp01(elapsedTime / time);//0-1�̒l�ɗ}����
            this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, p);//0-1�ŕ\����銄����3�ڂ̈���
            elapsedTime += Time.deltaTime;//�O�t���[������̌o�ߎ���(�b)������
            yield return null;//1�t���[���҂��ď������������ƂŃA�j���[�V�����݂����Ɍ����邽�߁B
        }
        this.gameObject.transform.position = endPos;//���r���[�Ȓl�ɂȂ�Ȃ��悤�ɍŏI���
        isMoving = false;
    }
}
//1�N���b�N����ƁA1�b������X���W���ړ�����B�ړ����̓N���b�N����Ă��������Ȃ��B
//�˃f�B���C���Ȃ��瓮�����˃R���[�`���g���H���`��Ԃł������̓_�𐄒肵�Ă��̓_�ō��݂Ȃ���I�_��ڎw���B
//�R���[�`���Ƃ́A�v���O�����̎��s���ꎞ��~���A��Œ��f�����ӏ����珈�����ĊJ�ł���
//Lerp(���`���)�A���m��2�̃f�[�^�_�̊Ԃɂ��関�m�̒l���A����2�_�����Ԓ�����̓_�Ƃ��Đ��肷���@