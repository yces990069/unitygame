using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroll : MonoBehaviour
{
    [SerializeField] private float sensX = 500f;//使用 SerializeField 屬性時，如果將變量設為 private ,但也希望它顯示在編輯器中就可使用。
    [SerializeField] private float sensY = 500f;//使用 SerializeField 屬性時，如果將變量設為 private ,但也希望它顯示在編輯器中就可使用。
    Camera cam;
    float mouseX;//滑標位置X
    float mouseY;//滑標位置Y

    float multiplier = -0.01f;//縮放器,用於調整部分屬性靈敏度
    float xRotation;//角色選轉X
    float yRotation;//角色選轉Y
    private void Start()
    {
        cam = GetComponentInChildren<Camera>();//回傳自身物件或其底下子物件擁有"Camera"的物件
        Cursor.lockState = CursorLockMode.Locked;//將鼠標鎖定至中央
        Cursor.visible = false;//將鼠標顯示設定為隱藏
    }
    private void Update()
    {
        MyInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);//transform.localRotation為相對於相當於父級旋轉的選轉變換
        transform.rotation = Quaternion.Euler(0, yRotation, 0);//Quaternion為四元數,Euler為由拉角 此函數是用於將歐拉角Vector3(x, y, z)對應的四元數Quaternion
    }
    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");//Input.GetAxisRaw("axis name")是用來返回axisName 標識的虛擬軸的值
        mouseY = Input.GetAxisRaw("Mouse Y");//
        yRotation -= mouseX * sensX * multiplier;
        xRotation += mouseY * sensY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//Mathf.Clamp是用來限制xRotation的運動或是選轉範圍的

    }
}
//附註 
//四元數為作為用於描述現實空間的座標表示方式，人們在複數的基礎上創造了四元數並以a+bi+cj+dk的形式說明空間點所在位置。
//i、j、k作為一種特殊的虛數單位參與運算，並有以下運算規則：i0=j0=k0=1，i2=j2=k2=-1
//reference from https://zh.wikipedia.org/wiki/%E5%9B%9B%E5%85%83%E6%95%B8#%E5%AE%9A%E7%BE%A9 (維基百科)