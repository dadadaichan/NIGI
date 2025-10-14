using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private float oneSec = 0;
    [SerializeField]
    private int maxTime;
    [SerializeField]
    private int second = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oneSec += Time.deltaTime;
        if(oneSec > 1f)
        {
            second++;
            Debug.Log(second);
            oneSec = 0f;
        }

        if(second == maxTime)
        {
            Debug.Log("TIME UP");
            sceneLoader.ResultScene();
        }
    }
}
