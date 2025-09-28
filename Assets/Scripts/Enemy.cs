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

    //void ReRegister()
    //{
    //    if (EnemyManager.Instance != null)
    //    {
    //        if()
    //    }
    //}

    void OnDisable()
    {
        EnemyManager.Instance.UnregisterEnemy(this.gameObject);
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
