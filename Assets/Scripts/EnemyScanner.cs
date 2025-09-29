using System.Collections;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public GameObject closestObj;
    //public GameObject longClosestObj;
    public GameObject closeLockOn;
    //public GameObject longLockOn;
    public GameObject closestPlayerCenter;
    //public GameObject longClosestPlayerCenter;

    public float lockOnInterval;
    public float closeLockOnAngle;
    //public float longLockOnAngle;
    public float closeLockOnScale;
    //public float longLockOnScale;
    public Vector3 dir;
    //public Vector3 dirLong;

    private GameObject preClosestObj;
    //private GameObject preLongClosestObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScanEnemy());
        //lockOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (closestObj == null)
        {
            if (closeLockOn != null)  // ここでチェック
            {
                closeLockOn.SetActive(false);
            }
        }

        //if (longClosestObj == null)
        //{
        //    if (longLockOn != null)  // ここでチェック
        //    {
        //        longLockOn.SetActive(false);
        //    }
        //}
    }

    IEnumerator ScanEnemy()
    {
        while (true)
        {
            float preDistancePlayerToEnemy = float.MaxValue;
            GameObject candidate = null;

            foreach (GameObject o in EnemyManager.Instance.closeRangeEnemies)
            {
                if (o == null || o.Equals(null)) continue; // Destroyされた敵は無視

                float distance = Vector3.Distance(transform.position, o.transform.position);
                if (distance < preDistancePlayerToEnemy)
                {
                    candidate = o;
                    preDistancePlayerToEnemy = distance;
                }
            }

            closestObj = candidate;

            if (closestObj != null && closestObj.CompareTag("CloseRangeEnemy"))
            {
                if (closeLockOn != null && !closeLockOn.Equals(null))
                {
                    closeLockOn.SetActive(true);
                    if (closestObj != preClosestObj)
                    {
                        closeLockOn.transform.SetParent(closestObj.transform, true);
                        closeLockOn.transform.localScale = new Vector3(closeLockOnScale, closeLockOnScale, 1);
                        closeLockOn.transform.localPosition = Vector3.zero;

                        preClosestObj = closestObj;
                    }
                }
            }
            else
            {
                // 敵がいない or DestroyされたらLockOn非表示
                if (closeLockOn != null && !closeLockOn.Equals(null))
                {
                    closeLockOn.SetActive(false);
                }
                closestObj = null;
            }

            if (closestObj != null && !closestObj.Equals(null))
            {
                dir = (closestObj.transform.position - closestPlayerCenter.transform.position).normalized;
                closeLockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            }

            yield return new WaitForSeconds(lockOnInterval);
        }
    }


    //public void AngleCal()
    //{
    //    if(nearestObj != null)
    //    {
    //        dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
    //        lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    }
    //    //dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
    //    //lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //}
}
//【目標】プレイヤーから最も近い敵をロックオンする。
//1.すべてのTag「Enemy」のオブジェクトを検索。⇒配列に入れる。
//※毎フレームやると重くなる、かつ、敵が多い場合ロックオンが荒ぶる。⇒数秒おきに実行。（IEnumeratorでコルーチン）
//2.配列内の一つ一つのオブジェクトとプレイヤーの距離を計算。（繰り返し処理）
//※foreach(GameObject o in 配列名）で「配列の中から一つ取り出して、oに代入して処理を行う。」を配列の終わりまで繰り返す。
//3.これまでの最短距離オブジェクト＞配列内の最短距離オブジェクト（if文）⇒後者をロックオン。
