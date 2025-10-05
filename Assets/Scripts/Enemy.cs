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

    void OnDisable()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.UnregisterEnemy(gameObject);
        }
    }

    public void die()
    {
        EnemyScanner scanner = FindFirstObjectByType<EnemyScanner>();
        if (scanner != null && scanner.closeLockOn != null)
        {
            scanner.closeLockOn.transform.SetParent(null); // 敵が消える前にlockonを外す
        }
        Destroy(this.gameObject);
    }
}
