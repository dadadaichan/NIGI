using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnEnable()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy(this.gameObject);
            //Debug.Log(gameObject + "をリストに追加するため、RegisterEnemyにアクセスします。");
        }
    }

    void OnDisable()
    {
        EnemyManager.Instance.UnregisterEnemy(this.gameObject);
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
