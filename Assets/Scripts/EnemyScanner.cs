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
            //近距離ロックオン
            float preDistancePlayerToEnemy = float.MaxValue;//最初に距離の最大入れとくことで一回目にどんな値が来ても最も短い距離と判定するため

            foreach (GameObject o in EnemyManager.Instance.closeRangeEnemies)
            {
                float distancePlayerToEnemy = Vector3.Distance(this.gameObject.transform.position, o.transform.position);
                if (distancePlayerToEnemy < preDistancePlayerToEnemy)
                {
                    closestObj = o;
                    preDistancePlayerToEnemy = distancePlayerToEnemy;
                }
            }
            if (closestObj != null && closestObj.CompareTag("CloseRangeEnemy"))
            {
                closeLockOn.SetActive(true);
                if (closestObj != preClosestObj)
                {
                    closeLockOn.transform.SetParent(closestObj.transform, true);
                    closeLockOn.transform.localScale = new Vector3(closeLockOnScale, closeLockOnScale, 1);
                    closeLockOn.transform.SetParent(closestObj.transform, false);
                    closeLockOn.transform.localPosition = new Vector3(0, 0, 0);
                    //closeLockOn.transform.localScale = new Vector3(3, 3, 1);
                    preClosestObj = closestObj;

                    //dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
                    //lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                }
            }
            //else
            //{
            //    closeLockOn.SetActive(false);
            //    closestObj = null;
            //}
            else if (closestObj == null || closestObj.Equals(null))
            {
                if (closeLockOn != null && !closeLockOn.Equals(null))
                {
                    closeLockOn.SetActive(false);
                }
                closestObj = null;
            }

            if (closestObj != null)
            {
                dir = (closestObj.transform.position - closestPlayerCenter.transform.position).normalized;
                closeLockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            }


            //遠距離ロックオン
            //float preDistancePlayerToEnemyLong = float.MaxValue;//最初に距離の最大入れとくことで一回目にどんな値が来ても最も短い距離と判定するため

            //foreach (GameObject o in EnemyManager.Instance.longRangeEnemies)
            //{
            //    float distancePlayerToEnemyLong = Vector3.Distance(this.gameObject.transform.position, o.transform.position);
            //    if (distancePlayerToEnemyLong < preDistancePlayerToEnemyLong)
            //    {
            //        longClosestObj = o;
            //        preDistancePlayerToEnemyLong = distancePlayerToEnemyLong;
            //    }
            //}

            //if (longClosestObj != null && longClosestObj.CompareTag("LongRangeEnemy"))
            //{
            //    longLockOn.SetActive(true);
            //    if(longClosestObj != preLongClosestObj)
            //    {
            //        longLockOn.transform.SetParent(longClosestObj.transform, true);
            //        longLockOn.transform.localScale = new Vector3(longLockOnScale, longLockOnScale, 1);
            //        longLockOn.transform.SetParent(longClosestObj.transform, false);
            //        longLockOn.transform.localPosition = new Vector3(0, 0, 0);
            //        //longLockOn.transform.localScale = new Vector3(7, 7, 1);
            //        preLongClosestObj = longClosestObj;

            //        //dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
            //        //lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //    }
            //}
            ////else
            ////{
            ////    longLockOn.SetActive(false);
            ////    longClosestObj = null;
            ////}
            //else if(longClosestObj == null || longClosestObj.Equals(null))
            //{
            //    if (longLockOn != null && !longLockOn.Equals(null))
            //    {
            //        longLockOn.SetActive(false);
            //    }
            //    longClosestObj = null;
            //}

            //if (longClosestObj != null)
            //{
            //    dirLong = (longClosestObj.transform.position - longClosestPlayerCenter.transform.position).normalized;
            //    longLockOnAngle = Mathf.Atan2(dirLong.y, dirLong.x) * Mathf.Rad2Deg;
            //}


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
