using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public Dictionary<int, SkillData> skillDataDic = new Dictionary<int, SkillData>();
    //装备初始
    public Dictionary<int, ItemData_Equipment> EquipDefineDic = new Dictionary<int, ItemData_Equipment>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
    }
    private void Init()
    {
        string filePath = Application.streamingAssetsPath + "/DataDefine.xlsx";

        FileInfo fileInfo = new FileInfo(filePath);

        SkillDefine(fileInfo);
        EquipDefine(fileInfo);
    }
    /// <summary>
    /// 读取技能数据
    /// </summary>
    /// <param name="fileInfo"></param>
    private void SkillDefine(FileInfo fileInfo)
    {
        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

            for (int i = 4; i <= worksheet.Dimension.End.Row; i++)
            {
                SkillData skillData = new SkillData();
                skillData.id = int.Parse(worksheet.Cells[i, 1].Value.ToString());

                skillData.job = int.Parse(worksheet.Cells[i, 2].Value.ToString());
                skillData.name = worksheet.Cells[i, 3].Value.ToString();
                skillData.prefabName = worksheet.Cells[i, 4].Value.ToString();
                skillData.duration = int.Parse(worksheet.Cells[i, 5].Value.ToString());
                skillData.anticipation = float.Parse(worksheet.Cells[i, 6].Value.ToString());
                skillData.speed = float.Parse(worksheet.Cells[i, 7].Value.ToString());
                skillDataDic[skillData.id] = skillData;
                //Debug.Log(worksheet.Cells[i, 1].Value + " " + worksheet.Cells[i, 2].Value + " " + worksheet.Cells[i, 4].Value);

            }
        }
    }
    /// <summary>
    /// 读取装备数据
    /// </summary>
    /// <param name="fileInfo"></param>
    private void EquipDefine(FileInfo fileInfo)
    {

        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[2];

            for (int i = 4; i <= worksheet.Dimension.End.Row; i++)
            {
                ItemData_Equipment itemData_Equipment = new ItemData_Equipment();
                itemData_Equipment.itemType = ItemType.Equipment;
                itemData_Equipment.id = int.Parse(worksheet.Cells[i, 1].Value.ToString());
                itemData_Equipment.name = worksheet.Cells[i, 2].Value.ToString();
                itemData_Equipment.itemName= worksheet.Cells[i, 3].Value.ToString();
                itemData_Equipment.equipType = (EquipType)int.Parse(worksheet.Cells[i, 4].Value.ToString());
                itemData_Equipment.health = float.Parse(worksheet.Cells[i, 5].Value.ToString());
                itemData_Equipment.mana = float.Parse(worksheet.Cells[i, 6].Value.ToString());
                itemData_Equipment.healthRegen = float.Parse(worksheet.Cells[i, 7].Value.ToString());
                itemData_Equipment.manaRegen = float.Parse(worksheet.Cells[i, 8].Value.ToString());
                itemData_Equipment.attackDamage = float.Parse(worksheet.Cells[i, 9].Value.ToString());
                itemData_Equipment.physicalPenetration = float.Parse(worksheet.Cells[i, 10].Value.ToString());
                itemData_Equipment.physicalResistance = float.Parse(worksheet.Cells[i, 11].Value.ToString());
                itemData_Equipment.abilityPower = float.Parse(worksheet.Cells[i, 12].Value.ToString());
                itemData_Equipment.spellPenetration = float.Parse(worksheet.Cells[i, 13].Value.ToString());
                itemData_Equipment.magicResistance = float.Parse(worksheet.Cells[i, 14].Value.ToString());
                itemData_Equipment.moveSpeed = float.Parse(worksheet.Cells[i, 15].Value.ToString());
                itemData_Equipment.dropChance = int.Parse(worksheet.Cells[i, 16].Value.ToString());
                EquipDefineDic[itemData_Equipment.id] = itemData_Equipment;
            }

        }
    }
}
