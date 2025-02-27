using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBallController : SkillController
{
    public override void Init(Transform target, SkillData skillData,CharacterStats stats)
    {
        base.Init(target, skillData , stats);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void MoveToTarget()
    {
        base.MoveToTarget();
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            EnemyStats enemyStats = target.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.DoDamage(stats);
            }
            Destroy(gameObject);
        }
    }

    protected override void Update()
    {
        base.Update();

    }
}
