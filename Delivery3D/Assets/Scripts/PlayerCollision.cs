using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] PathFollower patfollower;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Car"))
        {
            patfollower.enabled=false;
        }
    }
}
