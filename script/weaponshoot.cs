using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponshoot : MonoBehaviour
{
    public Transform BulletPoint;//開火點
    public GameObject BulletPre;//子彈預製體
    public Text BulletText;//連接UI上的子彈數量
    private int bulletCount = 30;//子彈數量的運算子
    private float cd = 0.1f;//開火間隔
    private float timer =0;
    
    void Update()
    {
        timer += Time.deltaTime;//時間變化
        if (timer > cd && Input.GetMouseButton(0) && bulletCount >0)//如果時間大於
        {
            timer = 0;
            //Instantiate(FirePre, FirePoint.position, FirePoint.rotation);
            Instantiate(BulletPre, BulletPoint.position, BulletPoint.rotation);
            bulletCount--;
            BulletText.text = bulletCount +"";

        }
        if(bulletCount==0)
        {
            BulletText.text = "Reloading";
            Invoke("Reload", 1.5f);
        }   
        if(Input.GetKeyDown(KeyCode.R))
        {
            BulletText.text = "Reloading";
            Invoke("Reload", 1.5f);
        }
    }
    void Reload()
    {
        bulletCount = 30;
        BulletText.text = bulletCount+"";
    }
}
