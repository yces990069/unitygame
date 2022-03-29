using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endgame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//檢測3D物件碰撞
    {
        if (other.tag=="Player")//如果碰撞物體的標籤為Player,則觸發以下事件
        {
            SceneManager.LoadScene("end");//切換至結束的頁面
            Cursor.visible = true;//將鼠標顯示設為顯示
            Cursor.lockState = CursorLockMode.None;//取消將鼠標鎖定頁面中央
        }
    }
}
D