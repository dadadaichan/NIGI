using Unity.VisualScripting;
using UnityEngine;

public class TentativeTakeDamage : MonoBehaviour
{
    public PlayerHP playerHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerHP.TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerHP.TakeDamage(2);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHP.Heal(1);
        }
    }
}
