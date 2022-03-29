using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIbehave : MonoBehaviour
{
    //以下為設定敵人所需要的變數
    public NavMeshAgent agent;//導航網格
    public Transform player;//玩家
    public LayerMask Ground, Player;//地面網格,玩家網格
    public bool canshoot;//判斷是否可以射擊

    public Transform BulletPointE;//敵人子彈發射點
    public GameObject BulletPreE;//敵人子彈預制體

    public Vector3 walkPoint;//敵人將走向的點
    bool walkPointSet;//是否設定敵人將走向的點
    public float walkPointRange;//走向點的距離

    public float timeBetweenAttacks;//攻擊間隔
    bool alreadyAttacked;//判斷是否正在攻擊

    public float sightRange, attackRange;//視野距離,攻擊距離
    public bool playerInSightRange, playerInAttackRange;//是否在視野內,是否在攻擊距離內
    //
    private void Start()
    {
        ani = GetComponent<Animator>();//從Unity中抓到動畫
        canshoot = true;//將判斷是否可以射擊條件設為可以
        ani.SetBool("die", false);//將Unity狀態基中的die條件設為否
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet"&& canshoot)  //如果碰撞物件為玩家的子彈且敵人是處於可射擊階段
        {            
            canshoot = false;//將敵人設不可射擊
            ani.SetBool("die", true);//將Unity狀態基中的die條件設為可以
            transform.LookAt(player);//將敵人的面相朝向玩家
            Invoke("Destroyobj", 1f);//觸發Destroyobj函式
        }
    }
    private void Destroyobj()
    {
        Destroy(gameObject);//摧毀本物件
    }
    private void Awake()
    {
        player = GameObject.Find("player").transform;//取得玩家的四元數
        agent = GetComponent<NavMeshAgent>();//取得導航網格
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);//
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);//
        if (!playerInSightRange && !playerInAttackRange && canshoot)//如果玩家不在敵人視野範圍內且不在攻擊範圍內且是可以射擊的狀態
        {
            Patroling();//執行巡邏
        }
        if (playerInSightRange && !playerInAttackRange && canshoot)//如果玩家在敵人視野範圍內且不在攻擊範圍內且是可以射擊的狀態
        {
            ChasePlayer();//執行追逐玩家
        }
        if (playerInSightRange && playerInAttackRange && canshoot)//如果玩家在敵人視野範圍內且在攻擊範圍內且是可以射擊的狀態
        {           
            AttackPlayer();//執行攻擊玩家
        }
    }
    private void Patroling()
    {
        ani.Play("move");//播放移動動畫
        if (!walkPointSet && canshoot) SearchWalkPoint();//當敵人不用尋找走向的點且可以射擊則巡邏
        if (walkPointSet && canshoot)//當敵人要尋找走向點時
                agent.SetDestination(walkPoint);//將找走向點設為終點後前進
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);//生成隨機的Z點
        float randomX = Random.Range(-walkPointRange, walkPointRange);//生成隨機的X點
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))//Physics.Raycast為向場景中的所有碰撞體投射一條射線，該射線起點為 / origin /，朝向 / direction /，長度為 / maxDistance /         
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()//追逐玩家
    {
        ani.Play("move");//播放走路動畫
        agent.SetDestination(player.position);//將玩家設定為終點後追逐
    }
    private void AttackPlayer()//攻擊玩家
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);//面相玩家
        if (!alreadyAttacked && canshoot)//如果未開火且可以射擊
        {
            Instantiate(BulletPreE, BulletPointE.position, BulletPointE.rotation);//生成子彈
            ani.Play("shoot");//播放射擊動畫
            alreadyAttacked = true;//將攻擊狀態設為正在攻擊
            Invoke(nameof(ResetAttack), timeBetweenAttacks);//間隔"timeBetweenAttacks"後觸發ResetAttack()
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;//將攻擊狀態設為未攻擊
    }
}