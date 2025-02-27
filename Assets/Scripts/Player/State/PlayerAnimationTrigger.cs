using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    /// <summary>
    /// 动画攻击结束 之后的时间是后摇可以点地面取消
    /// </summary>
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    /// <summary>
    /// 动画整个播放结束
    /// </summary>
    private void AnimationFinish()
    {
        player.AnimationFinish();
    }
}
