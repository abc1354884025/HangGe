using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    private bool encryptData = false;
    private string codeWord = "devcpp";

    public FileDataHandler(string dataDirPath, string dataFileName, bool encryptData)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.encryptData = encryptData;

    }
    /// <summary>
    /// 将GameData对象序列化为json字符串，并加密后保存到文件
    /// </summary>
    /// <param name="data"></param>
    public void Save(GameData data)
    {

        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            if (encryptData)
            {
                dataToStore = EncryptDecrypet(dataToStore);
            }

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.Write(dataToStore);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("Error saving data: " + e.Message);
        }
    }
    /// <summary>
    /// 将数据解密后反序列化为GameData对象
    /// </summary>
    /// <returns></returns>
    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadData = null;
        try
        {
            if (File.Exists(fullPath))
            {
                string dataAsJson = "";
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    dataAsJson = reader.ReadToEnd();
                }
                if (encryptData)
                {
                    dataAsJson = EncryptDecrypet(dataAsJson);
                }
                loadData = JsonUtility.FromJson<GameData>(dataAsJson);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("Error loading data: " + e.Message);
        }
        return loadData;

    }
    public void Delete()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
    private string EncryptDecrypet(string data)
    {
        string modifileData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifileData += (char)(data[i] ^ codeWord[i % codeWord.Length]);
        }
        return modifileData;
    }
}
