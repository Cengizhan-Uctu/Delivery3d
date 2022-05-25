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
        [SerializeField] float Maxspeed;
        public float speed = 0;
        public float distanceTravelled;

        void Start()
        {
            FindPath();
            if (pathCreator != null)
            {

                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            ////going back
            //if (Input.GetMouseButton(1))
            //{

            //    speed -= Time.deltaTime * 10;
            //    speed = Mathf.Clamp(speed, -10, 0);

            //}
            if (Input.GetMouseButton(0))
            {

                StopAllCoroutines();
                speed += Time.deltaTime * 10;
                speed = Mathf.Clamp(speed, 0, Maxspeed);

            }
            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(Slowe());

            }
            if (pathCreator != null)
            {
               // Debug.Log(pathCreator.path.length); buradaki length yolun tam uzunlugunu veriyor gaza bastıkca yolun ilerleme kısmını bundan faydalanarak yapabilirim
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
            while (speed >= 0)
            {
                speed -= Time.deltaTime * Damping;
                speed = Mathf.Clamp(speed, 0, 5);
                yield return new WaitForSeconds(0.01f);
            }
        }
        public void FindPath()
        {
            pathCreator = GameObject.FindGameObjectWithTag("PlayerPath").GetComponent<PathCreator>();
        }
    }
}