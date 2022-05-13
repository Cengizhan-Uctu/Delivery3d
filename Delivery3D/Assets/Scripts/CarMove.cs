using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarMove : MonoBehaviour
{
    
    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x + 50, transform.position.y, transform.position.z), 8);
    }

   
    void Update()
    {
        
    }
}
