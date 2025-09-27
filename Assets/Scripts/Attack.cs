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
        Debug.Log("�o��: " + other.gameObject.name);

        if (enemyScanner.nearestObj != null) // null�`�F�b�N
        {
            Transform lockOnChild = enemyScanner.nearestObj.transform.Find("LockOn");
            if (lockOnChild != null)
            {
                lockOnChild.SetParent(null);
            }
        }

        // ������폜�i�G������Ώۂɂ���Ȃ�^�O�`�F�b�N����ƈ��S�j
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
