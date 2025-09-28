using UnityEngine;

public class Attack : MonoBehaviour
{
    public EnemyScanner enemyScanner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemyScanner.nearestObj != null) // nullチェック
        {
            Transform lockOnChild = enemyScanner.nearestObj.transform.Find("LockOn");
            if (lockOnChild != null)
            {
                lockOnChild.SetParent(null);
            }
        }

        // 相手を削除
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("撃破: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

}
