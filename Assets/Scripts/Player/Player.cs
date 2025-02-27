using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;
using Mirror.Examples.Benchmark;
public class Player : Entity
{




    public Camera camera { get; private set; }
    public PlayerStateMachine stateMachine {  get; private set; }
    public SkillManager skill;
    public PlayerStats stats;


    public Vector3 destination;
    public Transform target;
    public Transform selectedTarget;
    private Enemy enemy;

    //点击地面生成箭头
    public GameObject arrow;
    int layerMask=0;

    #region States
    public PlayerMoveState MoveState { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerNormalAttackState NormalAttackState { get; private set; }
    public PlayerSpinningState SpinningState { get; private set; }

    #endregion

    #region MegaSkillStates
    public MegaFireBallState megaFireBallState { get; private set; }
    public MegaLightningBallState MegaLightningBallState { get; private set; }

    #endregion


    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
        stats = GetComponent<PlayerStats>();
        skill = GetComponentInChildren<SkillManager>();
        stateMachine = new PlayerStateMachine();
        MoveState = new PlayerMoveState(this, stateMachine, "Move");
        IdleState = new PlayerIdleState(this, stateMachine, "Idle");
        NormalAttackState = new PlayerNormalAttackState(this, stateMachine, "NormalAttack");
        SpinningState = new PlayerSpinningState(this, stateMachine, "Spinning");




        
        stateMachine.Initialize(IdleState);


        layerMask = ~(1 << 10 | 1 << 11);
    }
    protected override void Start()
    {
        base.Start();
        #region MegaSkillStates
        megaFireBallState = new MegaFireBallState(this, stateMachine, "Cast");
        MegaLightningBallState = new MegaLightningBallState(this, stateMachine, "Cast");
        #endregion
    }

    // Update is called once per frame
    protected override void Update()
    {
        //if (!isLocalPlayer) return;
        Debug.DrawLine(transform.position, destination, Color.red);
        MouseRays();

        base.Update();
        stateMachine.currentState.Update();
        if (Input.GetKeyDown(KeyCode.Q)&&target != null)
        {
            skill.lightningBall.CanUseSkill();
        }
    }
    /// <summary>
    /// 鼠标发射射线
    /// </summary>
    public virtual void MouseRays()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit,10000,layerMask))
        {
            destination = hit.point;
            //Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Enemy>() != null)
            {
                if(enemy!= null)
                {
                    enemy.MouseExit();
                }
                enemy = hit.transform.GetComponent<Enemy>();
                enemy.MouseEnter();
                target = hit.transform;
            }
            else
            {
                if (enemy != null)
                {
                    enemy.MouseExit();
                }
                target = null;
                enemy = null;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(arrow, hit.point, Quaternion.identity);
            }
            
        }
    }

    /// <summary>
    /// 动画攻击结束 之后的时间是后摇可以点地面取消
    /// </summary>
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    /// <summary>
    /// 动画整个播放结束
    /// </summary>
    public void AnimationFinish() => stateMachine.currentState.AnimationFinishPlay();
}
