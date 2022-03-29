using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [Header("Movement")]
    float playerHeight = 2f;//玩家高度
    float horizontalMovement;//垂直移動
    float verticalMovement;//水平移動
    public float moveSpeed = 6f;//移動速度
    Vector3 moveDirection;//移動方向
    Rigidbody rb;//將鋼體的變數設為rb
    [Header("Keybinds")]
    [SerializeField] KeyCode jumpkey = KeyCode.Space;//將空白建設為跳躍紐
    bool isGrounded;//檢查是接觸地面
    [Header("Jumping")]
    public float jumpForce = 5f;//跳躍力度
    [Header("Drag")]
    public float groundDrag = 8f;//地面摩擦力
    public float airDrag = 12f;//空氣阻力
    [SerializeField]
    public float airMultiplier = 0.8f;//用於調整空氣的
    private void Start()
    {
        rb = GetComponent<Rigidbody>();//從遊戲中讀取到鋼體
        rb.freezeRotation = true;//鎖定旋轉
    }
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight/2-0.6f);//檢測是否接觸地面
        if (Input.GetKeyDown(jumpkey) && isGrounded)
        {
            Jump();//執行跳躍的函式
        }
        ControlDrag();
        MyInput();

    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce,ForceMode.Impulse);//施加跳躍作用力
    }
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");//返回垂直虛擬軸的值
        verticalMovement = Input.GetAxisRaw("Vertical");//返回水平虛擬軸的值
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;//決定移動方向
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        if(isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);//施加作用力使物體移動
        }
        else if(!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed* airMultiplier, ForceMode.Acceleration);//施加作用力使物體移動
        }
    }
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;//將鋼體的摩擦力設為在地面得摩擦力
        }
        else
        {
            rb.drag = airDrag;//將鋼體的摩擦力設為在空中得摩擦力
        }
    }
}
