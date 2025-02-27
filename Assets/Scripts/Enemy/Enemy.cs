using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror.Examples.Benchmark;
public class Enemy : Entity
{

   [SerializeField]private Transform SelectedSign;


    //[Header("��ⷶΧ")]
    [SerializeField] public float attackRange { get; private set; } = 1.5f;//������Χ
    [SerializeField] public float detectionRange { get; private set; } = 10f;//��֪��Χ

    private SphereCollider detectionCollider;
    public Transform target;

    #region States
    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemySlashState slashState { get; private set; }
    public EnemyTauntState tauntState { get; private set; }

    #endregion

    public EnemyStateMachine stateMachine { get; private set; }
    


    protected override void Awake()
    {
        base.Awake();
        detectionCollider = GetComponentInChildren<SphereCollider>();
        stateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, stateMachine, "Idle");
        moveState = new EnemyMoveState(this, stateMachine, "Move");
        slashState = new EnemySlashState(this, stateMachine, "Slash");
        tauntState = new EnemyTauntState(this, stateMachine, "Taunt");


    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        detectionCollider.radius = detectionRange;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    /// <summary>
    /// ������������ ֮���ʱ���Ǻ�ҡ���Ե����ȡ��
    /// </summary>
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    /// <summary>
    /// �����������Ž���
    /// </summary>
    public virtual void AnimationFinish() => stateMachine.currentState.AnimationFinishPlay();

    /// <summary>
    /// ���ѡ��
    /// </summary>
    public virtual void MouseEnter()
    {
        SelectedSign?.gameObject.SetActive(true);
    }

    /// <summary>
    /// ����Ƴ�
    /// </summary>
    public virtual void MouseExit()
    {
        SelectedSign?.gameObject.SetActive(false);

    }
}
