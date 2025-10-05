using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public EnemyScanner enemyScanner;
    
    void Start()
    {
        
    }
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