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
        Debug.Log("出た: " + other.gameObject.name);

        if (enemyScanner.nearestObj != null) // nullチェック
        {
            Transform lockOnChild = enemyScanner.nearestObj.transform.Find("LockOn");
            if (lockOnChild != null)
            {
                lockOnChild.SetParent(null);
            }
        }

        // 相手を削除（敵だけを対象にするならタグチェックすると安全）
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
