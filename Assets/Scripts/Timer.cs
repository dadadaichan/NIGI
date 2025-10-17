using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private float oneSec = 1;
    [SerializeField]
    private int maxTime;
    [SerializeField]
    private int remainingTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        oneSec -= Time.deltaTime;
        if(oneSec <= 0f)
        {
            remainingTime--;
            //Debug.Log(remainingTime);
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            if (minutes < 0)
            {
                timerText.text = seconds.ToString();
            }
            else
            {
                timerText.text = (minutes + ":" + seconds.ToString("00"));
            }
            oneSec = 1f;
        }

        if(remainingTime == 0)
        {
            Debug.Log("TIME UP");
            sceneLoader.ResultScene();
        }
    }
}
