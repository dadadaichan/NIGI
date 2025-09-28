using System.Collections;
using UnityEngine;

public class PlayerGauge : MonoBehaviour
{
    public int maxGauge = 8;
    public int currentGauge;
    public AttackEffect attackEffect;
    public GameObject attackEffectG;
    public int gaugeHealValue;
    public float gaugeHealTime;

    public float elapsedTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGauge = maxGauge;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;//ゲージ減少アクションが最後に行われてからの経過秒数

        if (attackEffect.isAttacking)//攻撃したら、秒数初期化
        {
            elapsedTime = 0;
        }

        if (elapsedTime >= gaugeHealTime)//回復
        {
            currentGauge += gaugeHealValue;
            if(currentGauge > maxGauge) currentGauge = maxGauge;
            elapsedTime = 0;
        }

        if(currentGauge == 0)
        {

        }
    }

    public void GaugeDecrease(int gaugeDecrease)
    {
        currentGauge -= gaugeDecrease;
        if (currentGauge < 0)
        {
            currentGauge = 0;
        }
    }
}
//ゲージが0になると、移動速度低下、攻撃できない、ガードできない。
//移動と方向転換はできる。
//ゲージが満タンになるまで、以上の行動ができない。
//5秒かけて、ゲージが満タンになる。ゲージがたまると、諸々復活。
