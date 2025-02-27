using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    private Enemy enemy => GetComponentInParent<Enemy>();
    /// <summary>
    /// ������������ ֮���ʱ���Ǻ�ҡ���Ե����ȡ��
    /// </summary>
    private void AnimationTrigger()
    {
        enemy.AnimationTrigger();
    }
    /// <summary>
    /// �����������Ž���
    /// </summary>
    private void AnimationFinish()
    {
        enemy.AnimationFinish();
    }
}
