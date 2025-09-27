using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour
{
    public Image[] heart;
    public Sprite redHeart;
    public Sprite blackHeart;
    public PlayerHP playerHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            for(int i = 0;  i < heart.Length; i++)
            {
                if(playerHP.currentHP > i)
                {
                    heart[i].sprite = redHeart;
                }
                else
                {
                    heart[i].sprite = blackHeart;
                }
            }
    }
}
