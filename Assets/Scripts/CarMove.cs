using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarMove : MonoBehaviour
{
    [SerializeField] float speed;
    bool East;
    bool West;
    bool South;
    bool North;

    private void Start()
    {
        East = gameObject.transform.parent.GetComponent<CarSpawn>().East;
        West = gameObject.transform.parent.GetComponent<CarSpawn>().West;
        South = gameObject.transform.parent.GetComponent<CarSpawn>().South;
        North = gameObject.transform.parent.GetComponent<CarSpawn>().North;
    }
    private void Update()
    {
        if (East)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            transform.rotation =Quaternion.Euler( new Vector3(0, 0, 0));
        }
        if (West)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (South)
        {

            transform.position += Vector3.back * Time.deltaTime * -speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (North)
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

    }
}
