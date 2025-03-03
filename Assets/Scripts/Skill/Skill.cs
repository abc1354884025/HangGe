using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkillName
{
    fireball=1,
    lightningBall = 2,
    iceSpear,
    poisonCloud,
}
public class Skill : MonoBehaviour
{
    protected SkillName skillName;
    protected SkillData skillData;



    [SerializeField] private float cooldown;
    private float cooldownTimer;
    [SerializeField] private string prefabPath;
    [SerializeField] protected SkillController prefab;



    private Player player;//
    public virtual bool CanUseSkill()
    {
        if (cooldownTimer < 0)
        {

            return true;
        }
        return false;
    }

    public virtual void UseSkill()
    {
        cooldownTimer = cooldown;

        SkillController skillController = Instantiate(prefab, player.AttackPoint.position, Quaternion.identity);
        skillController.Init(player.selectedTarget, skillData,player.stats);
    }
    protected virtual void Awake()
    {

    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
        skillData = SaveManager.instance.skillDataDic[(int)skillName];
        prefab = Resources.Load<SkillController>("SkillPrefab/" + skillData.prefabName);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        
    }

}
