using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static EnemyManager Instance
    {
        get;
        private set;
    }

    public List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //Debug.Log("Instance‚ª‘¶İ‚µ‚Ä‚¢‚È‚©‚Á‚½‚Ì‚ÅInstance‚ğ¶¬‚µ‚Ü‚µ‚½B");
        }
        else
        {
            Destroy(this.gameObject);
            //Debug.Log("Instance‚ª‘¶İ‚µ‚Ä‚¢‚½‚Ì‚Å‚±‚ÌInstance‚ğíœ‚µ‚Ü‚µ‚½B");
        }
    }
    public void RegisterEnemy(GameObject enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
            //Debug.Log(enemy + "‚ğEnemyList‚É“o˜^‚µ‚Ü‚µ‚½B");
        }
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy)) enemies.Remove(enemy);
    }
}
