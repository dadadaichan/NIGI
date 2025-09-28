using System.Collections;
using UnityEngine;

public class PlayerGauge : MonoBehaviour
{
    public int maxGauge = 8;
    public int currentGauge;
    public AttackEffect attackEffect;
    public GameObject attackEffectG;
    public int gaugeHealValue;
    public float startGaugeHealTime;
    public float gaugeHealTime;
    public float zeroGaugeHealTime;
    public bool isZeroGauge = false;
    public BoatRotateType rotateType;

    public float elapsedTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGauge = maxGauge;
        gaugeHealTime = startGaugeHealTime;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;//�Q�[�W�����A�N�V�������Ō�ɍs���Ă���̌o�ߕb��

        if (attackEffect.isAttacking && !isZeroGauge)//�U��������A�b��������
        {
            elapsedTime = 0;
        }

        if (elapsedTime >= gaugeHealTime)//��
        {
            currentGauge += gaugeHealValue;
            if(currentGauge > maxGauge) currentGauge = maxGauge;
            elapsedTime = 0;
        }

        if(isZeroGauge)
        {
            gaugeHealTime = zeroGaugeHealTime;
            if(currentGauge == maxGauge)//�S�񕜂�����
            {
                isZeroGauge = false;
                gaugeHealTime = startGaugeHealTime;
                rotateType.moveSpeed = rotateType.ms;
            }
        }
    }

    public void GaugeDecrease(int gaugeDecrease)
    {
        currentGauge -= gaugeDecrease;
        if (currentGauge <= 0)
        {
            currentGauge = 0;
            rotateType.moveSpeed = rotateType.gaugeDownSlow;
            isZeroGauge = true;
        }
    }
}
//�Q�[�W��0�ɂȂ�ƁA�ړ����x�ቺ�A�U���ł��Ȃ��A�K�[�h�ł��Ȃ��B
//�ړ��ƕ����]���͂ł���B
//�Q�[�W�����^���ɂȂ�܂ŁA�ȏ�̍s�����ł��Ȃ��B
//5�b�����āA�Q�[�W�����^���ɂȂ�B�Q�[�W�����܂�ƁA���X�����B
