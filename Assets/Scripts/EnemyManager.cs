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
            //Debug.Log("Instance�����݂��Ă��Ȃ������̂�Instance�𐶐����܂����B");
        }
        else
        {
            Destroy(this.gameObject);
            //Debug.Log("Instance�����݂��Ă����̂ł���Instance���폜���܂����B");
        }
    }
    public void RegisterEnemy(GameObject enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
            //Debug.Log(enemy + "��EnemyList�ɓo�^���܂����B");
        }
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy)) enemies.Remove(enemy);
    }
}
