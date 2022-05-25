using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject Character;
   [SerializeField] Vector3 distance;
    private void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");
        //distance = transform.position - Character.transform.position;

    }
    private void LateUpdate()
    {
        transform.position = Character.transform.position + distance;
       
    }


}