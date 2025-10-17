using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI killCountText;
    public int killCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillCount()
    {
        killCount++;
        killCountText.text = ("KILL:" + killCount);
        Debug.Log("KILLCOUNTÅF" + killCount);

    }
}
