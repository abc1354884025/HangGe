using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Transform target { get; private set; }
    public SkillData skillData;
    private float duration;
    private float speed;
    protected CharacterStats stats;
    public virtual void Init(Transform target,SkillData skillData,CharacterStats stats)
    {
        this.target = target;
        this.skillData = skillData;
        duration = skillData.duration;
        speed = skillData.speed;
        this.stats = stats;

    }
    public virtual void OnEnable()
    {

    }
    protected virtual void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                Destroy(gameObject);
            }
        }
        MoveToTarget();
    }
    protected virtual void MoveToTarget()
    {
        if (target == null) return;
        if(speed != 0)
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }   
}
