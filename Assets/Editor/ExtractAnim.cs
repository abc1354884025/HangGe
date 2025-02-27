using System.IO;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class ExtractAnim : MonoBehaviour
{
    [MenuItem("Assets/һ�����ɶ���Ƭ��", false, 1)]
    static void CreateAnimFromFBX()
    {
        UnityEngine.Object[] gameObjects = Selection.objects;
        string[] strs = Selection.assetGUIDs;

        if (gameObjects.Length > 0)
        {
            int gameNum = gameObjects.Length;
            for (int i = 0; i < gameNum; i++)
            {
                string fbxName = gameObjects[i].name;
                string assetPath = AssetDatabase.GUIDToAssetPath(strs[i]);
                //Debug.Log(assetPath); //���嵽fbx��·��
                string animFolder = Path.GetDirectoryName(assetPath) + "/Anim";
                // ��������ڸ��ļ����򴴽�һ���µ�
                if (!AssetDatabase.IsValidFolder(animFolder))
                {
                    AssetDatabase.CreateFolder(Path.GetDirectoryName(assetPath), "Anim");
                }
                // ��ȡassetPath��������Դ
                Object[] assets = AssetDatabase.LoadAllAssetsAtPath(assetPath);
                bool isCreate = false;
                List<Object> animation_clip_list = new List<Object>();
                foreach (Object item in assets)
                {
                    if (typeof(AnimationClip) == item?.GetType())//�ҵ�fbx����Ķ���
                    {
                        Debug.Log("�ҵ�����Ƭ�Σ�" + item);
                        if (!item.name.StartsWith("__preview"))
                        {
                            animation_clip_list.Add(item);
                        }
                    }
                }

                foreach (AnimationClip animation_clip in animation_clip_list)
                {

                    Object new_animation_clip = new AnimationClip();
                    EditorUtility.CopySerialized(animation_clip, new_animation_clip);
                    new_animation_clip.name = Path.GetFileNameWithoutExtension(assetPath);
                    string animation_path = Path.Combine(animFolder, animation_clip.name+ ".anim");
                    Debug.Log(animation_path);
                    AssetDatabase.CreateAsset(new_animation_clip, animation_path);

                    isCreate = true;
                }
                //AssetDatabase.DeleteAsset(assetPath);
                AssetDatabase.Refresh();
                if (isCreate)
                    Debug.Log("�Զ���������Ƭ�γɹ���" + animFolder);
                else
                    Debug.Log("δ�Զ���������Ƭ�Ρ�");

            }
        }
        else
        {
            Debug.LogError("��ѡ����Ҫһ����ȡ����Ƭ�ε�ģ��");
        }
    }
}