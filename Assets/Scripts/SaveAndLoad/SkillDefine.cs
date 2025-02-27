using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class SkillDefine : MonoBehaviour
{
    public static SkillDefine instance;

    public Dictionary<int, SkillData> skillDataDic= new Dictionary<int, SkillData>();
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
        ReadExcel();
    }
    private void ReadExcel()
    {
        string filePath = Application.streamingAssetsPath + "/SkillDefine.xlsx";

        FileInfo fileInfo = new FileInfo(filePath);

        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];    

            for(int i = 4; i <= worksheet.Dimension.End.Row; i++)
            {
                SkillData skillData = new SkillData();
                skillData.id = int.Parse(worksheet.Cells[i, 1].Value.ToString());
                
                skillData.job = int.Parse(worksheet.Cells[i, 2].Value.ToString());
                skillData.name = worksheet.Cells[i, 3].Value.ToString();
                skillData.prefabName = worksheet.Cells[i, 4].Value.ToString();
                skillDataDic[skillData.id] = skillData;
                Debug.Log(worksheet.Cells[i, 1].Value + " " + worksheet.Cells[i, 2].Value + " " + worksheet.Cells[i, 4].Value);

            }
        }
    }

}
