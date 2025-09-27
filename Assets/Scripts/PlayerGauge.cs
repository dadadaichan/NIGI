using System.Collections;
using UnityEngine;

public class PlayerGauge : MonoBehaviour
{
    public int maxGauge = 8;
    public int currentGauge;
    public AttackEffect attackEffect;
    public float gaugeHealSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGauge = maxGauge;
       //StartCoroutine(GaugeHeal)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GaugeDecrease(int gaugeDecrease)
    {
        //if (attackEffect.isAttacking)//今はとりあえずアタックだけ
        //{
            currentGauge -= gaugeDecrease;
        if(currentGauge < 0)currentGauge = 0;
        //}
    }

    IEnumerator GaugeHeal()
    {
        while (true)
        {

            yield return new WaitForSeconds(gaugeHealSpeed);
        }
    }
}
