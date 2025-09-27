using UnityEngine;
using UnityEngine.UI;

public class UIGauge : MonoBehaviour
{
    public Sprite[] gaugeImages;
    public PlayerGauge playerGauge;
    public Image gauge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < gaugeImages.Length; i++)
        {
            if (playerGauge.currentGauge == i)
            {
                gauge.sprite = gaugeImages[i];
;           }
        }
        
    }
}
