using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public Vector3 moveOffset = new Vector3(1f, 0, 0);//移動量
    public float moveTime = 1f;//移動時間
    private bool isMoving = false;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) && !isMoving)
        {
            StartCoroutine(LerpMove(moveTime,-moveOffset));
        }

        if (Input.GetKeyUp(KeyCode.D) && !isMoving)
        {
            StartCoroutine(LerpMove(moveTime, moveOffset));
        }
    }

    IEnumerator LerpMove(float time, Vector3 offset)
    {
        isMoving = true;
        Vector3 startPos = this.gameObject.transform.position;
        Vector3 endPos = startPos + offset;
        float elapsedTime = 0;//経過時間
        float p = 0;//0－1で表される割合。この値に応じてstartPosとendPosの間の推定点が決まってくる。

        while (elapsedTime < time)//1秒経過するまで繰り返す
        {
            p = Mathf.Clamp01(elapsedTime / time);//0-1の値に抑える
            this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, p);//0-1で表される割合が3つ目の引数
            elapsedTime += Time.deltaTime;//前フレームからの経過時間(秒)をたす
            yield return null;//1フレーム待って少しずつ動くことでアニメーションみたいに見せるため。
        }
        this.gameObject.transform.position = endPos;//中途半端な値にならないように最終代入
        isMoving = false;
    }
}
//1クリックすると、1秒かけてX座標を移動する。移動中はクリックされても反応しない。
//⇒ディレイしながら動かす⇒コルーチン使う？線形補間であいだの点を推定してその点で刻みながら終点を目指す。
//コルーチンとは、プログラムの実行を一時停止し、後で中断した箇所から処理を再開できる
//Lerp(線形補間)、既知の2つのデータ点の間にある未知の値を、その2点を結ぶ直線上の点として推定する手法