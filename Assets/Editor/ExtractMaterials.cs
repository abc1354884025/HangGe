using System.IO;
using UnityEngine;
using UnityEditor;
/// <summary>
/// ʹ�÷������Ҽ�ѡ����Ҫ��ȡ�������fbx�ļ����ɶ�ѡ����ѡ��һ�����ɲ����򡰣�
/// ��ͬ���ļ����л����Material�ļ��У�������ȡ�����Ĳ������ļ���������ͬ�Ĳ�������Զ�ƥ�䵽�������ظ����ɡ�
/// </summary>
public class ExtractMaterials : EditorWindow
{
    [MenuItem("Assets/һ�����ɲ�����", false, 1)]
    static void CreateMaterialsFromFBX()
    {
        UnityEngine.Object[] gameObjects = Selection.objects;
        string[] strs = Selection.assetGUIDs;

        if (gameObjects.Length > 0)
        {
            int gameNum = gameObjects.Length;
            for (int i = 0; i < gameNum; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(strs[i]);
                //Debug.Log(assetPath); //���嵽fbx��·��
                string materialFolder = Path.GetDirectoryName(assetPath) + "/Materials";
                // ��������ڸ��ļ����򴴽�һ���µ�
                if (!AssetDatabase.IsValidFolder(materialFolder))
                {
                    AssetDatabase.CreateFolder(Path.GetDirectoryName(assetPath), "Materials");
                }
                // ��ȡassetPath��������Դ
                Object[] assets = AssetDatabase.LoadAllAssetsAtPath(assetPath);
                bool isCreate = false;
                foreach (Object item in assets)
                {
                    if (typeof(Material) == item?.GetType())//�ҵ�fbx����Ĳ���
                    {
                        Debug.Log("�ҵ������ļ���" + item);
                        string path = System.IO.Path.Combine(materialFolder, item.name) + ".mat";//��ȡ�������
                        if (System.IO.File.Exists(path))
                        {
                            Debug.Log("�ò����Ѵ���");

                            var assetImporter = AssetImporter.GetAtPath(assetPath);
                            var clone = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
                            assetImporter.AddRemap(new AssetImporter.SourceAssetIdentifier(item), clone);
                            AssetDatabase.WriteImportSettingsIfDirty(assetPath);
                            AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                        }
                        else
                        {
                            path = AssetDatabase.GenerateUniqueAssetPath(path);
                            string value = AssetDatabase.ExtractAsset(item, path);
                            if (string.IsNullOrEmpty(value))
                            {
                                AssetDatabase.WriteImportSettingsIfDirty(assetPath);
                                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                                isCreate = true;
                            }
                        }
                    }
                }

                AssetDatabase.Refresh();
                if (isCreate)
                    Debug.Log("�Զ�����������ɹ���" + materialFolder);
            }
        }
        else
        {
            Debug.LogError("��ѡ����Ҫһ�����ɲ������ģ��");
        }
    }
}