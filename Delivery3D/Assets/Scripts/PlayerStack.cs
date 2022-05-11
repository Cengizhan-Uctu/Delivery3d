using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    [SerializeField] GameObject Basket;
    float newPos;
    private void Start()
    {
        newPos=1.5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.transform.parent = Basket.transform;
            other.transform.localPosition = new Vector3(0,newPos,0);
            other.transform.rotation = Basket.transform.rotation;
            newPos +=2f;

        }
    }
}
