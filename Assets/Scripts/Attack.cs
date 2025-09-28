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
        if (enemyScanner.nearestObj != null) // null�`�F�b�N
        {
            Transform lockOnChild = enemyScanner.nearestObj.transform.Find("LockOn");
            if (lockOnChild != null)
            {
                lockOnChild.SetParent(null);
            }
        }

        // ������폜
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("���j: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }

}
