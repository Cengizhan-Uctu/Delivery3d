using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using System;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] GameObject Basket;
    [SerializeField] GameObject scooter;
    public List<GameObject> Boxs = new List<GameObject>();
    public List<GameObject> MoneyList = new List<GameObject>();
    PathFollower patfollower;
    int boxForce = 1;
    float gameEndSpeed;
    bool isGameEnd = false;

    private void Start()
    {
        patfollower = GetComponent<PathFollower>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Car"))
        {
            StartCoroutine(CrashCar(collision));
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Boxs.Add(collision.gameObject);
            PlayerStack.Instance.Stack(collision);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Customer"))
        {
            TurnIntoMoney(other.GetComponent<Customer>().OutGoingBoxNumber);
            other.gameObject.tag = "Untagged";
        }
        if (other.CompareTag("FinishLine"))
        {
            TurnIntoMoney(Boxs.Count);
            isGameEnd = true;
            gameEndSpeed = 8;
            StartCoroutine(SceneProsses.Instance.ISceneChange(0.1f));
        }
    }
    private void Update()
    {
        if (isGameEnd)
        {
            ////BASKETE BAK
            //Basket.GetComponent<StackRotate>().enabled = false;
            //Basket.transform.parent = null;
            //Basket.transform.Translate(Vector3.right * Time.deltaTime * -gameEndSpeed);
            //if (Basket.transform.childCount == 0)
            //{

            //    gameEndSpeed = 0;
            //    isGameEnd = false;
            //    Basket.transform.parent = gameObject.transform;
            //}
        }
    }
    void DispersalBox(Collision other)
    {
        foreach (var Box in Boxs)
        {
            boxForce += 8;
            Box.transform.parent = null;
            Box.gameObject.tag = "Untagged";
            Box.AddComponent<Rigidbody>();
            Vector3 Newvector = VectorCalculate(Box.transform.position, other.transform.position);
            Box.GetComponent<Rigidbody>().AddForce(Newvector * -boxForce);
        }
        foreach (var Money in MoneyList)
        {
            boxForce += 8;
            Money.transform.parent = null;
            Money.gameObject.tag = "Untagged";
            Money.AddComponent<Rigidbody>();
            Vector3 Newvector = VectorCalculate(Money.transform.position, other.transform.position);
            Money.GetComponent<Rigidbody>().AddForce(Newvector * -boxForce);

        }

    }
    void TurnIntoMoney(int OutGoingBox)
    {
        for (int i = 0; i < OutGoingBox; i++)
        {
            try
            {
                Boxs[0].transform.GetChild(0).gameObject.SetActive(false);
                Boxs[0].transform.GetChild(1).gameObject.SetActive(true);
                Boxs[0].transform.gameObject.tag = "Basket";
                MoneyList.Add(Boxs[0]);
                Boxs.Remove(Boxs[0]);
            }
            catch (ArgumentOutOfRangeException)
            {
                // print("eksik kargo");
            }
        }
    }

    IEnumerator CrashCar(Collision collision)
    {
        rigidBody.useGravity = true;
        patfollower.enabled = false;
        Vector3 Newvector = VectorCalculate(transform.position, collision.transform.position);
        Newvector.y = 0;
        rigidBody.AddForce(-Newvector.normalized * -boxForce * 3);
        DispersalBox(collision);
        collision.gameObject.GetComponent<CarMove>().enabled = false;
        collision.gameObject.GetComponent<Collider>().enabled = false;
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        yield return new WaitForSeconds(1);
        CheckPoint();
        StopCoroutine("CrashCar");
    }
    void CheckPoint()
    {
        PlayerStack.Instance.newPos = 0.5f;
        patfollower.distanceTravelled -= 6f;
        patfollower.speed = 0;
        patfollower.enabled = true;
    }
    Vector3 VectorCalculate(Vector3 vectorone, Vector3 vectortow)
    {
        Vector3 newVector3 = vectorone - vectortow;
        return newVector3;
    }
}
