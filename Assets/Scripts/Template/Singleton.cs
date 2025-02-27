using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Pool;
/// <summary>
/// µ¥ÀýÄ£°åÀà
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