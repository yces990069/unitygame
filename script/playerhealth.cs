using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    public int PlayerHealth;//玩家血量
    public Text health;//玩家血量(在UI上顯示的)
    public int ph=100;//玩家血量(作為運算子用)
    bool alive = true;//是否存活
    private void Start()
    {
        alive = true;//將存活狀態設為真
    }
    void Update()
    {
        if (ph<=0)//如果血量<=0
        {
            alive = false;//將存活狀態設為否
            SceneManager.LoadScene("die");//切換到死亡的場景
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="BulletE" && alive)//如果碰撞標籤為BulletE且為存活狀態
        {
            ph = ph - 10;//生命減10
            health.text = ph + "";//更新UI上顯示的血量
        }
    }
}
