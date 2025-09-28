using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy(this.gameObject);
            //Debug.Log(gameObject + "をリストに追加するため、RegisterEnemyにアクセスします。");
        }
    }

    //void ReRegister()
    //{
    //    if (EnemyManager.Instance != null)
    //    {
    //        if()
    //    }
    //}

    void OnDisable()
    {
        EnemyManager.Instance.UnregisterEnemy(this.gameObject);
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
