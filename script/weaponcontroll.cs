using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponcontroll: MonoBehaviour
{
    [Header("Sway Setting")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;//�\���F�ӫ׽վ㾹

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;//���o�ƹ�������X�b
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;//���o�ƹ�������Y�b
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);//�Ыؤ@�ӳ�¶ mouseY ���� angle �ת�����
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);//�Ыؤ@�ӳ�¶ mouseX ���� angle �ת�����
        Quaternion targetRotation = rotationX * rotationY;//����
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);//�b�|���� a �P b ��������v t �i��y�δ���,�óЫؤ@�ӱ���A�H���Ѽƪ��� a�A�b�Ĥ@�ӥ|���� a ��ĤG�ӥ|���� b �������ƶi�洡��
    }
}
