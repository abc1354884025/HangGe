using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public LightningBallSkill lightningBall;
    public FireBallSkill fireBall;
    private Player player;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
        lightningBall=GetComponent<LightningBallSkill>();
        fireBall = GetComponent<FireBallSkill>();
    }
}
