using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PathCreation.Examples
{
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        [SerializeField] float Damping;
        float speed = 0;
        float distanceTravelled;

        void Start() 
        {
            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
               
                StopAllCoroutines();
                speed+=Time.deltaTime*10;
                speed = Mathf.Clamp(speed, 0, 10);
     
            }   
            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(Slowe());
               
            }
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }
       
        void OnPathChanged() 
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
        IEnumerator Slowe()
        {
            while (speed>=0)
            {
                speed -= Time.deltaTime * Damping;
                speed = Mathf.Clamp(speed, 0, 5);
                yield return new WaitForSeconds(0.01f);
            }
           
           
        }
    }
}