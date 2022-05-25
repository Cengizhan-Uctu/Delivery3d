using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public bool East = false;
    public bool West = false;
    public bool South = false;
    public bool North = false;
    [SerializeField] GameObject[] CarPrefab;
    [SerializeField] float spawnRare;
    GameObject[] Cars;
    int currentCar;
    int nexCar;
    void Start()
    {
        currentCar = 0;
        Cars = new GameObject[CarPrefab.Length];
        CarPool();
        StartCoroutine(SpawnCar());
    }
    void CarPool()
    {

        for (int i = 0; i < CarPrefab.Length; i++)
        {
            GameObject NewCar = Instantiate(CarPrefab[currentCar], transform.position, Quaternion.identity);
            NewCar.SetActive(false);
            NewCar.transform.parent = transform;
            currentCar++;
            Cars[i] = NewCar;
            if (currentCar == Cars.Length)
            {
                currentCar = 0;
            }

        }
    }
    IEnumerator SpawnCar()
    {
        while (true)
        {
            Cars[nexCar].transform.position = transform.position;
            Cars[nexCar].SetActive(true);
            nexCar++;
            yield return new WaitForSeconds(spawnRare);
            if (nexCar == Cars.Length)
            {
                nexCar = 0;
            }
        }
    }
}
