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
        EnemyScanner scanner = FindFirstObjectByType<EnemyScanner>();
        if (scanner != null && scanner.closeLockOn != null)
        {
            scanner.closeLockOn.transform.SetParent(null); // 敵が消える前に外す
        }

        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.UnregisterEnemy(gameObject);
        }
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
