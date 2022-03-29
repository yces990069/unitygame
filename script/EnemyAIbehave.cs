using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIbehave : MonoBehaviour
{
    //�H�U���]�w�ĤH�һݭn���ܼ�
    public NavMeshAgent agent;//�ɯ����
    public Transform player;//���a
    public LayerMask Ground, Player;//�a������,���a����
    public bool canshoot;//�P�_�O�_�i�H�g��

    public Transform BulletPointE;//�ĤH�l�u�o�g�I
    public GameObject BulletPreE;//�ĤH�l�u�w����

    public Vector3 walkPoint;//�ĤH�N���V���I
    bool walkPointSet;//�O�_�]�w�ĤH�N���V���I
    public float walkPointRange;//���V�I���Z��

    public float timeBetweenAttacks;//�������j
    bool alreadyAttacked;//�P�_�O�_���b����

    public float sightRange, attackRange;//�����Z��,�����Z��
    public bool playerInSightRange, playerInAttackRange;//�O�_�b������,�O�_�b�����Z����
    //
    private void Start()
    {
        ani = GetComponent<Animator>();//�qUnity�����ʵe
        canshoot = true;//�N�P�_�O�_�i�H�g������]���i�H
        ani.SetBool("die", false);//�NUnity���A�򤤪�die����]���_
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet"&& canshoot)  //�p�G�I�����󬰪��a���l�u�B�ĤH�O�B��i�g�����q
        {            
            canshoot = false;//�N�ĤH�]���i�g��
            ani.SetBool("die", true);//�NUnity���A�򤤪�die����]���i�H
            transform.LookAt(player);//�N�ĤH�����۴¦V���a
            Invoke("Destroyobj", 1f);//Ĳ�oDestroyobj�禡
        }
    }
    private void Destroyobj()
    {
        Destroy(gameObject);//�R��������
    }
    private void Awake()
    {
        player = GameObject.Find("player").transform;//���o���a���|����
        agent = GetComponent<NavMeshAgent>();//���o�ɯ����
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);//
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);//
        if (!playerInSightRange && !playerInAttackRange && canshoot)//�p�G���a���b�ĤH�����d�򤺥B���b�����d�򤺥B�O�i�H�g�������A
        {
            Patroling();//���樵��
        }
        if (playerInSightRange && !playerInAttackRange && canshoot)//�p�G���a�b�ĤH�����d�򤺥B���b�����d�򤺥B�O�i�H�g�������A
        {
            ChasePlayer();//����l�v���a
        }
        if (playerInSightRange && playerInAttackRange && canshoot)//�p�G���a�b�ĤH�����d�򤺥B�b�����d�򤺥B�O�i�H�g�������A
        {           
            AttackPlayer();//����������a
        }
    }
    private void Patroling()
    {
        ani.Play("move");//���񲾰ʰʵe
        if (!walkPointSet && canshoot) SearchWalkPoint();//��ĤH���δM�䨫�V���I�B�i�H�g���h����
        if (walkPointSet && canshoot)//��ĤH�n�M�䨫�V�I��
                agent.SetDestination(walkPoint);//�N�䨫�V�I�]�����I��e�i
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);//�ͦ��H����Z�I
        float randomX = Random.Range(-walkPointRange, walkPointRange);//�ͦ��H����X�I
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))//Physics.Raycast���V���������Ҧ��I�����g�@���g�u�A�Ӯg�u�_�I�� / origin /�A�¦V / direction /�A���׬� / maxDistance /         
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()//�l�v���a
    {
        ani.Play("move");//���񨫸��ʵe
        agent.SetDestination(player.position);//�N���a�]�w�����I��l�v
    }
    private void AttackPlayer()//�������a
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);//���۪��a
        if (!alreadyAttacked && canshoot)//�p�G���}���B�i�H�g��
        {
            Instantiate(BulletPreE, BulletPointE.position, BulletPointE.rotation);//�ͦ��l�u
            ani.Play("shoot");//����g���ʵe
            alreadyAttacked = true;//�N�������A�]�����b����
            Invoke(nameof(ResetAttack), timeBetweenAttacks);//���j"timeBetweenAttacks"��Ĳ�oResetAttack()
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;//�N�������A�]��������
    }
}