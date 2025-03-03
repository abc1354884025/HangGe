using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public LightningBallSkill lightningBall;
    public FireBallSkill fireBall;
    private Player player;
    private void Awake()
    {
        
        lightningBall=GetComponent<LightningBallSkill>();
        fireBall = GetComponent<FireBallSkill>();
    }
    private void Start()
    {
        player = PlayerManager.instance.player;
    }
}
