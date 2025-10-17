using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public EnemyScanner enemyScanner;
    public KillCounter killCounter;
    
    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemyScanner.closestObj != null) // null�`�F�b�N
        {
            Transform lockOnChild = enemyScanner.closestObj.transform.Find("LockOn");
            if (lockOnChild != null)
            {
                lockOnChild.SetParent(null);
            }
        }

        // ������폜
        if (other.CompareTag("CloseRangeEnemy"))
        {
            killCounter.KillCount();
            Destroy(other.gameObject);
        }
    }

}