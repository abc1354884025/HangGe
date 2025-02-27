using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGroundArrow : MonoBehaviour
{
    public Transform arrow;
    // Start is called before the first frame update
    void Start()
    {
        Tween tween = arrow.DOLocalMoveY(0.5f, 1f);
        tween.OnComplete(() => Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
