using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [Header("Movement")]
    float playerHeight = 2f;//���a����
    float horizontalMovement;//��������
    float verticalMovement;//��������
    public float moveSpeed = 6f;//���ʳt��
    Vector3 moveDirection;//���ʤ�V
    Rigidbody rb;//�N���骺�ܼƳ]��rb
    [Header("Keybinds")]
    [SerializeField] KeyCode jumpkey = KeyCode.Space;//�N�ťիس]�����D��
    bool isGrounded;//�ˬd�O��Ĳ�a��
    [Header("Jumping")]
    public float jumpForce = 5f;//���D�O��
    [Header("Drag")]
    public float groundDrag = 8f;//�a�������O
    public float airDrag = 12f;//�Ů���O
    [SerializeField]
    public float airMultiplier = 0.8f;//�Ω�վ�Ů�
    private void Start()
    {
        rb = GetComponent<Rigidbody>();//�q�C����Ū�������
        rb.freezeRotation = true;//��w����
    }
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight/2-0.6f);//�˴��O�_��Ĳ�a��
        if (Input.GetKeyDown(jumpkey) && isGrounded)
        {
            Jump();//������D���禡
        }
        ControlDrag();
        MyInput();

    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce,ForceMode.Impulse);//�I�[���D�@�ΤO
    }
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");//��^���������b����
        verticalMovement = Input.GetAxisRaw("Vertical");//��^���������b����
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;//�M�w���ʤ�V
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        if(isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);//�I�[�@�ΤO�Ϫ��鲾��
        }
        else if(!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed* airMultiplier, ForceMode.Acceleration);//�I�[�@�ΤO�Ϫ��鲾��
        }
    }
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;//�N���骺�����O�]���b�a���o�����O
        }
        else
        {
            rb.drag = airDrag;//�N���骺�����O�]���b�Ť��o�����O
        }
    }
}
