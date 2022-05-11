using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StackRotate : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 1), 0.3f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo);
    }
}
