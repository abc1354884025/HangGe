using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror.Examples.Benchmark;
public class Enemy : Entity
{

   [SerializeField]private Transform SelectedSign;


    //[Header("检测范围")]
    [SerializeField] public float attackRange { get; private set; } = 1.5f;//攻击范围
    [SerializeField] public float detectionRange { get; private set; } = 10f;//感知范围

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
    /// 动画攻击结束 之后的时间是后摇可以点地面取消
    /// </summary>
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    /// <summary>
    /// 动画整个播放结束
    /// </summary>
    public virtual void AnimationFinish() => stateMachine.currentState.AnimationFinishPlay();

    /// <summary>
    /// 鼠标选中
    /// </summary>
    public virtual void MouseEnter()
    {
        SelectedSign?.gameObject.SetActive(true);
    }

    /// <summary>
    /// 鼠标移出
    /// </summary>
    public virtual void MouseExit()
    {
        SelectedSign?.gameObject.SetActive(false);

    }
}
