using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    /// <summary>
    /// ������������ ֮���ʱ���Ǻ�ҡ���Ե����ȡ��
    /// </summary>
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    /// <summary>
    /// �����������Ž���
    /// </summary>
    private void AnimationFinish()
    {
        player.AnimationFinish();
    }
}
