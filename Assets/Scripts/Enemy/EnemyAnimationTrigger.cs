using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    private Enemy enemy => GetComponentInParent<Enemy>();
    /// <summary>
    /// 动画攻击结束 之后的时间是后摇可以点地面取消
    /// </summary>
    private void AnimationTrigger()
    {
        enemy.AnimationTrigger();
    }
    /// <summary>
    /// 动画整个播放结束
    /// </summary>
    private void AnimationFinish()
    {
        enemy.AnimationFinish();
    }
}
