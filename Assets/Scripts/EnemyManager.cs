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

    public List<GameObject> longRangeEnemies = new List<GameObject>();
    public List<GameObject> closeRangeEnemies = new List<GameObject>();

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
        //if (!longRangeEnemies.Contains(enemy)  || !closeRangeEnemies.Contains(enemy))
        //{
        //    if (enemy.CompareTag("LongRangeEnemy"))
        //    {
        //        longRangeEnemies.Add(enemy);
        //    }
        //    else if(enemy.CompareTag("CloseRangeEnemy"))
        //    {
        //        closeRangeEnemies.Add(enemy);
        //    }
        //}

        if (!longRangeEnemies.Contains(enemy) && enemy.CompareTag("LongRangeEnemy"))
        {
            longRangeEnemies.Add(enemy);
            closeRangeEnemies.Remove(enemy);
        }

        if (!closeRangeEnemies.Contains(enemy) && enemy.CompareTag("CloseRangeEnemy"))
        {
            closeRangeEnemies.Add(enemy);
            longRangeEnemies.Remove(enemy);
        }

        //Debug.Log("‹ß‹——£“G”:" + closeRangeEnemies.Count);
        //Debug.Log("‰“‹——£“G”:" + longRangeEnemies.Count);
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        if (longRangeEnemies.Contains(enemy) || closeRangeEnemies.Contains(enemy))
        {
            if (enemy.CompareTag("LongRangeEnemy"))
            {
                longRangeEnemies.Remove(enemy);
            }
            else if (enemy.CompareTag("CloseRangeEnemy"))
            {
                closeRangeEnemies.Remove(enemy);
            }
            //Debug.Log(enemy + "‚ğEnemyList‚É“o˜^‚µ‚Ü‚µ‚½B");
        }
        //if (longRangeEnemies.Contains(enemy)) longRangeEnemies.Remove(enemy);
    }
}
