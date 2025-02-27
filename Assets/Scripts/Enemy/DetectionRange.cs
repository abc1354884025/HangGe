using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour
{
    public  Enemy enemy;
    public Transform transform;
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<Player>()!= null)
        {
            Debug.Log("Player detected");
            if(enemy.target == null)
            {
                enemy.target = other.transform;
                transform=other.transform;
            }
        }
    }
}
