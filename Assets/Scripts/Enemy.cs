using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy(this.gameObject);
            //Debug.Log(gameObject + "�����X�g�ɒǉ����邽�߁ARegisterEnemy�ɃA�N�Z�X���܂��B");
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
            scanner.closeLockOn.transform.SetParent(null); // �G��������O��lockon���O��
        }
        Destroy(this.gameObject);
    }
}
