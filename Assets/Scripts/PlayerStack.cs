using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : SingeltonGeneric<PlayerStack>
{
    [SerializeField] GameObject Basket;
    public float newPos;
    #region singelton
    private void Awake()
    {
        MakeSingelton(this);
    }
#endregion
    private void Start()
    {
        newPos=.5f;
    }
   public void Stack(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            collision.gameObject.transform.parent = Basket.transform;
            collision.transform.localPosition = new Vector3(0, newPos, 0);
            collision.transform.rotation = Basket.transform.rotation;
            newPos += 2.9f;
        }
    }
}
