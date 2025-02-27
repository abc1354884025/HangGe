using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Pool;
/// <summary>
/// ����ģ����
/// </summary>
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Instance = this;
        }
        
    }


}