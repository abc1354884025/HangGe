using Mirror.Examples.Benchmark;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    private CharacterStats myStats;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        
        myStats = GetComponentInParent<CharacterStats>();
        slider = GetComponentInChildren<Slider>();
        myStats.onHealthChange += UpdateHealthBar;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform);
        //使用  Vector3.ProjectOnPlane （投影向量，投影平面法向量）用于计算某个向量在某个平面上的投影向量  
        Vector3 lookPoint = Vector3.ProjectOnPlane(this.transform.position - Camera.main.transform.position, Camera.main.transform.forward);
        this.transform.LookAt(Camera.main.transform.position + lookPoint);
    }
    private void OnDisable()
    {
        //myStats.onHealthChange -= UpdateHealthBar;
    }
    private void UpdateHealthBar()
    {

        slider.maxValue = myStats.GetMaxHealth();
        slider.value = myStats.GetHealth();
    }
}
