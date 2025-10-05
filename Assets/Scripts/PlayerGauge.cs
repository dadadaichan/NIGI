using System.Collections;
using UnityEngine;

public class PlayerGauge : MonoBehaviour
{
    public int maxGauge = 8;
    public int currentGauge;
    public Attack attack;
    public GameObject attackEffectG;
    public int gaugeHealValue;
    public float startGaugeHealTime;
    public float gaugeHealTime;
    public float zeroGaugeHealTime;
    public bool isZeroGauge = false;
    public BoatRotateType rotateType;
    public ArrowRange arrowRange;

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
        elapsedTime += Time.deltaTime;//ゲージ減少アクションが最後に行われてからの経過秒数

        if (!isZeroGauge)//攻撃したら、秒数初期化
        {
            if(attack.isAttacking || arrowRange.isArrowFire)
            elapsedTime = 0;
        }

        if (elapsedTime >= gaugeHealTime)//回復
        {
            currentGauge += gaugeHealValue;
            if(currentGauge > maxGauge) currentGauge = maxGauge;
            elapsedTime = 0;
        }

        if(isZeroGauge)
        {
            gaugeHealTime = zeroGaugeHealTime;
            if(currentGauge == maxGauge)//全回復したら
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
//ゲージが0になると、移動速度低下、攻撃できない、ガードできない。
//移動と方向転換はできる。
//ゲージが満タンになるまで、以上の行動ができない。
//5秒かけて、ゲージが満タンになる。ゲージがたまると、諸々復活。
