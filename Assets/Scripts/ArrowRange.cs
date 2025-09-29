using System.Collections.Generic;
using UnityEngine;

public class ArrowRange : MonoBehaviour
{
    public CapsuleCollider2D col;
    public float area;
    public int maxTargets = 5;
    public List<GameObject> targets = new List<GameObject>();
    public GameObject arrowLockOnPf;
    public PlayerGauge playerGauge;
    public int arrowGaugeDecrease;
    public bool isArrowFire = false;

    // 生成したロックオンオブジェクトを管理するリスト
    private List<GameObject> activeLockOns = new List<GameObject>();

    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
        col = GetComponent<CapsuleCollider2D>();
        col.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //col.enabled = true;
            //transform.localScale += new Vector3(area, area, 0); // += にすると毎フレーム拡大し続けるので修正

            //// まだロックオンマーカーが付いていない敵にだけ生成
            //foreach (GameObject arrowTarget in new List<GameObject>(targets)) // コピーしてforeach
            //{
            //    if (arrowTarget != null && !HasLockOn(arrowTarget))
            //    {
            //        GameObject lockOn = Instantiate(arrowLockOnPf, arrowTarget.transform.position, Quaternion.identity);
            //        lockOn.transform.SetParent(arrowTarget.transform, false); // 子にする
            //        lockOn.transform.localPosition = Vector3.zero;            // 敵の中心に配置
            //        activeLockOns.Add(lockOn);                                // リストに登録
            //    }
            //}
            if (!playerGauge.isZeroGauge)
            {
                ArrowLoad();
            }
            
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            //playerGauge.GaugeDecrease(arrowGaugeDecrease);
            //// 全ロックオン削除
            //foreach (GameObject lockOn in activeLockOns)
            //{
            //    if (lockOn != null)
            //        Destroy(lockOn);
            //}
            //activeLockOns.Clear();

            //// ロックオンした敵をすべて破壊
            //foreach (GameObject arrowTarget in new List<GameObject>(targets))
            //{
            //    if (arrowTarget != null)
            //    {
            //        Destroy(arrowTarget);
            //    }
            //}
            //targets.Clear();

            //transform.localScale = baseScale;
            //col.enabled = false;
            if (!playerGauge.isZeroGauge)
            {
                ArrowFire();
            }
        }
    }

    private void ArrowLoad()
    {
        col.enabled = true;
        transform.localScale += new Vector3(area, area, 0); // += にすると毎フレーム拡大し続けるので修正

        // まだロックオンマーカーが付いていない敵にだけ生成
        foreach (GameObject arrowTarget in new List<GameObject>(targets)) // コピーしてforeach
        {
            if (arrowTarget != null && !HasLockOn(arrowTarget))
            {
                GameObject lockOn = Instantiate(arrowLockOnPf, arrowTarget.transform.position, Quaternion.identity);
                lockOn.transform.SetParent(arrowTarget.transform, false); // 子にする
                lockOn.transform.localPosition = Vector3.zero;            // 敵の中心に配置
                activeLockOns.Add(lockOn);                                // リストに登録
            }
        }
        isArrowFire = true;
    }

    private void ArrowFire()
    {
        playerGauge.GaugeDecrease(arrowGaugeDecrease);
        // 全ロックオン削除
        foreach (GameObject lockOn in activeLockOns)
        {
            if (lockOn != null)
                Destroy(lockOn);
        }
        activeLockOns.Clear();

        // ロックオンした敵をすべて破壊
        foreach (GameObject arrowTarget in new List<GameObject>(targets))
        {
            if (arrowTarget != null)
            {
                Destroy(arrowTarget);
            }
        }
        targets.Clear();

        transform.localScale = baseScale;
        col.enabled = false;
        isArrowFire = false;
    }

    private bool HasLockOn(GameObject target)
    {
        foreach (GameObject lockOn in activeLockOns)
        {
            if (lockOn != null && lockOn.transform.parent == target.transform)
                return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CloseRangeEnemy") && !targets.Contains(other.gameObject))
        {
            if (targets.Count < maxTargets)
            {
                targets.Add(other.gameObject);
                Debug.Log("敵を追加: " + other.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
            Debug.Log("敵を削除: " + other.name);
        }
    }
}
