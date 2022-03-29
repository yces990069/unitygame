using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroll : MonoBehaviour
{
    [SerializeField] private float sensX = 500f;//�ϥ� SerializeField �ݩʮɡA�p�G�N�ܶq�]�� private ,���]�Ʊ楦��ܦb�s�边���N�i�ϥΡC
    [SerializeField] private float sensY = 500f;//�ϥ� SerializeField �ݩʮɡA�p�G�N�ܶq�]�� private ,���]�Ʊ楦��ܦb�s�边���N�i�ϥΡC
    Camera cam;
    float mouseX;//�ƼЦ�mX
    float mouseY;//�ƼЦ�mY

    float multiplier = -0.01f;//�Y��,�Ω�վ㳡���ݩ��F�ӫ�
    float xRotation;//�������X
    float yRotation;//�������Y
    private void Start()
    {
        cam = GetComponentInChildren<Camera>();//�^�Ǧۨ�����Ψ䩳�U�l����֦�"Camera"������
        Cursor.lockState = CursorLockMode.Locked;//�N������w�ܤ���
        Cursor.visible = false;//�N������ܳ]�w������
    }
    private void Update()
    {
        MyInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);//transform.localRotation���۹��۷����ű��઺�����ܴ�
        transform.rotation = Quaternion.Euler(0, yRotation, 0);//Quaternion���|����,Euler���ѩԨ� ����ƬO�Ω�N�کԨ�Vector3(x, y, z)�������|����Quaternion
    }
    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");//Input.GetAxisRaw("axis name")�O�ΨӪ�^axisName ���Ѫ������b����
        mouseY = Input.GetAxisRaw("Mouse Y");//
        yRotation -= mouseX * sensX * multiplier;
        xRotation += mouseY * sensY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//Mathf.Clamp�O�Ψӭ���xRotation���B�ʩάO����d��

    }
}
//���� 
//�|���Ƭ��@���Ω�y�z�{��Ŷ����y�Ъ�ܤ覡�A�H�̦b�Ƽƪ���¦�W�гy�F�|���ƨåHa+bi+cj+dk���Φ������Ŷ��I�Ҧb��m�C
//i�Bj�Bk�@���@�دS����Ƴ��ѻP�B��A�æ��H�U�B��W�h�Gi0=j0=k0=1�Ai2=j2=k2=-1
//reference from https://zh.wikipedia.org/wiki/%E5%9B%9B%E5%85%83%E6%95%B8#%E5%AE%9A%E7%BE%A9 (����ʬ�)