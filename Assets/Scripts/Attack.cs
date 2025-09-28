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
        if (enemyScanner.closestObj != null) // nullチェック
        {
            Transform lockOnChild = enemyScanner.closestObj.transform.Find("LockOn");
            if (lockOnChild != null)
            {
                lockOnChild.SetParent(null);
            }
        }

        // 相手を削除
        if (other.CompareTag("CloseRangeEnemy"))
        {
            Debug.Log("撃破: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

}
