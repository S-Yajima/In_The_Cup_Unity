using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    // オブジェクトを生成するインターバルタイム
    private float interval_time = 3.0f;
    // 前回生成実行時からの蓄積時間。Time.deltaを加算する
    private float delta_time = 0.0f;

    // スフィアのPrefab。色毎に個別のPrefabとしたが別の方法もある可能性あり。
    public GameObject sphere_Prefab_Red;
    public GameObject sphere_Prefab_Blue;
    public GameObject sphere_Prefab_Green;
    public GameObject sphere_Prefab_Yellow;

    // 生成対象のスフィアPrefab配列とインデックス番号
    private int index = 0;
    private GameObject[] sphereList = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        // 配列にPrefabを格納する
        this.sphereList[0] = this.sphere_Prefab_Blue;
        this.sphereList[1] = this.sphere_Prefab_Red;
        this.sphereList[2] = this.sphere_Prefab_Green;
        this.sphereList[3] = this.sphere_Prefab_Yellow;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta_time += Time.deltaTime;
        if (this.delta_time >= this.interval_time)
        {
            this.delta_time = 0.0f;

            // 対象のインデックス番号のスフィアPrefabを生成する
            if (this.index >= this.sphereList.Length) this.index = 0;
            GameObject sphere = Instantiate(this.sphereList[this.index]);

            // スフィアを放出する方向(Vector3)をランダムで決定する
            int py = Random.Range(50, 59);
            // 生成したスフィアに力を加えて放出する
            sphere.GetComponent<Rigidbody>().AddForce(new Vector3(-52.0f, (float)py, 0.0f));
            // 対象のスフィアPrefabのインデックスインデックス番号をインクリメントする
            this.index += 1;
        }

    }
}
