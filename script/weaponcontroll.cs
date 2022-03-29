using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponcontroll: MonoBehaviour
{
    [Header("Sway Setting")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;//擺動靈敏度調整器

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;//取得滑鼠的虛擬X軸
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;//取得滑鼠的虛擬Y軸
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);//創建一個圍繞 mouseY 旋轉 angle 度的旋轉
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);//創建一個圍繞 mouseX 旋轉 angle 度的旋轉
        Quaternion targetRotation = rotationX * rotationY;//旋轉
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);//在四元數 a 與 b 之間按比率 t 進行球形插值,並創建一個旋轉，以基於參數的值 a，在第一個四元數 a 到第二個四元數 b 之間平滑進行插值
    }
}
