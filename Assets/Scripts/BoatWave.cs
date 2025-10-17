using UnityEngine;

public class BoatWave : MonoBehaviour
{
    [SerializeField] private GameObject wavePf;
    [SerializeField] private float threshold = 1f;   // �g���o���Ԋu
    [SerializeField] private float destroyDelay = 2f; // �g��������܂ł̎���
    [SerializeField] private Vector3 localPosR;
    [SerializeField] private Vector3 localPosL;
    private float interval;

    void Update()
    {
        interval += Time.deltaTime;

        if (interval > threshold)
        {
            
            Vector3 wavePos = this.transform.TransformPoint(localPosR);
            Quaternion waveRot = transform.rotation;
            Vector3 waveSize = new Vector3(1, 1, 1);
            GameObject w = Instantiate(wavePf, wavePos, waveRot);
            w.transform.localScale = waveSize;

            wavePos = this.transform.TransformPoint(localPosL);
            GameObject wL = Instantiate(wavePf, wavePos, waveRot);
            wL.transform.localScale = waveSize;

            // ��莞�Ԍ�Ɏ����폜
            Destroy(w, destroyDelay);
            Destroy(wL, destroyDelay);

            interval = 0;
        }
    }
}
