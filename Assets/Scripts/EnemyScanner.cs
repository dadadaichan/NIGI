using System.Collections;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public GameObject closestObj;
    public GameObject longClosestObj;
    public GameObject closeLockOn;
    public GameObject longLockOn;
    public GameObject closestPlayerCenter;
    public GameObject longClosestPlayerCenter;

    public float lockOnInterval;
    public float lockOnAngle;
    public Vector3 dir;
    public Vector3 dirLong;

    private GameObject preClosestObj;
    private GameObject preLongClosestObj;
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
            closeLockOn.SetActive(false);
        }
    }

    IEnumerator ScanEnemy()
    {
        while (true)
        {
            //�ߋ������b�N�I��
            float preDistancePlayerToEnemy = float.MaxValue;//�ŏ��ɋ����̍ő����Ƃ����Ƃň��ڂɂǂ�Ȓl�����Ă��ł��Z�������Ɣ��肷�邽��

            foreach (GameObject o in EnemyManager.Instance.closeRangeEnemies)
            {
                float distancePlayerToEnemy = Vector3.Distance(this.gameObject.transform.position, o.transform.position);
                if (distancePlayerToEnemy < preDistancePlayerToEnemy)
                {
                    closestObj = o;
                    preDistancePlayerToEnemy = distancePlayerToEnemy;
                }
            }
            if (closestObj != null)
            {
                closeLockOn.SetActive(true);
                if (closestObj != preClosestObj)
                {
                    closeLockOn.transform.SetParent(closestObj.transform, false);
                    closeLockOn.transform.localPosition = new Vector3(0, 0, 0);
                    closeLockOn.transform.localScale = new Vector3(3, 3, 1);
                    preClosestObj = closestObj;

                    //dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
                    //lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                }
            }
            else
            {
                closeLockOn.SetActive(false);
                closestObj = null;
            }
            if (closestObj != null)
            {
                dir = (closestObj.transform.position - closestPlayerCenter.transform.position).normalized;
                lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            }


            //���������b�N�I��
            float preDistancePlayerToEnemyLong = float.MaxValue;//�ŏ��ɋ����̍ő����Ƃ����Ƃň��ڂɂǂ�Ȓl�����Ă��ł��Z�������Ɣ��肷�邽��

            foreach (GameObject o in EnemyManager.Instance.longRangeEnemies)
            {
                float distancePlayerToEnemyLong = Vector3.Distance(this.gameObject.transform.position, o.transform.position);
                if (distancePlayerToEnemyLong < preDistancePlayerToEnemyLong)
                {
                    longClosestObj = o;
                    preDistancePlayerToEnemy = distancePlayerToEnemyLong;
                }
            }

            if (longClosestObj != null)
            {
                longLockOn.SetActive(true);
                if(longClosestObj != preLongClosestObj)
                {
                    longLockOn.transform.SetParent(longClosestObj.transform, false);
                    longLockOn.transform.localPosition = new Vector3(0, 0, 0);
                    longLockOn.transform.localScale = new Vector3(7, 7, 1);
                    preLongClosestObj = longClosestObj;

                    //dir = (nearestObj.transform.position - playerCenter.transform.position).normalized;
                    //lockOnAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                }
            }
            else
            {
                longLockOn.SetActive(false);
                longClosestObj = null;
            }
            if (longClosestObj != null)
            {
                dirLong = (longClosestObj.transform.position - longClosestPlayerCenter.transform.position).normalized;
                lockOnAngle = Mathf.Atan2(dirLong.y, dirLong.x) * Mathf.Rad2Deg;
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
//�y�ڕW�z�v���C���[����ł��߂��G�����b�N�I������B
//1.���ׂĂ�Tag�uEnemy�v�̃I�u�W�F�N�g�������B�˔z��ɓ����B
//�����t���[�����Əd���Ȃ�A���A�G�������ꍇ���b�N�I�����r�Ԃ�B�ː��b�����Ɏ��s�B�iIEnumerator�ŃR���[�`���j
//2.�z����̈��̃I�u�W�F�N�g�ƃv���C���[�̋������v�Z�B�i�J��Ԃ������j
//��foreach(GameObject o in �z�񖼁j�Łu�z��̒��������o���āAo�ɑ�����ď������s���B�v��z��̏I���܂ŌJ��Ԃ��B
//3.����܂ł̍ŒZ�����I�u�W�F�N�g���z����̍ŒZ�����I�u�W�F�N�g�iif���j�ˌ�҂����b�N�I���B
