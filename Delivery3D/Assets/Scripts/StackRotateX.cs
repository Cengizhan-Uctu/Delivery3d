using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackRotateX : MonoBehaviour
{
    float rotationx;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            Rotatex();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(RotateDegresX());
        }

    }

    void Rotatex()
    {
        StopAllCoroutines();
        rotationx += Time.deltaTime * 50;
        rotationx = Mathf.Clamp(rotationx, 0, 10);
        transform.localRotation = Quaternion.Euler(rotationx, 0, 0);
    }
    IEnumerator RotateDegresX()
    {
        while (rotationx >= 0)
        {
            rotationx -= Time.deltaTime * 50;
            rotationx = Mathf.Clamp(rotationx, 0, 10);
            transform.localRotation = Quaternion.Euler(rotationx, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
