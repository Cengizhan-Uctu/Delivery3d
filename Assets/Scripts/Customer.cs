using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public int OutGoingBoxNumber;
    [SerializeField] Text OutGoingBoxText;
    [SerializeField] GameObject sad;
    [SerializeField] GameObject happy;
    CustomerAnimation customerAnimation;
        
    private void Start()
    {
        customerAnimation = GetComponent<CustomerAnimation>();
        OutGoingBoxText.text ="x"+ OutGoingBoxNumber.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OutGoingBoxNumber <= other.GetComponent<PlayerCollision>().Boxs.Count)
            {
             
                happy.SetActive(true);
                customerAnimation.Victory();
            }
            else
            {
                sad.SetActive(true);
                customerAnimation.Victory();
            }

        }
    }
}
