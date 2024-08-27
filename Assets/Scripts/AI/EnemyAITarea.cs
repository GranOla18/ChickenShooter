using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAITarea : MonoBehaviour
{
    public Transform[] points;
    //public List<GameObject> pointsPatroll;
    public int nextPoint;
    public float speed;

    public NavMeshAgent navAgent;
    public Transform player;

    public Collider sight;

    public int waitInPoint;
    public bool foundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //player = ChickenManager.instance.gameObject.transform;
        nextPoint = 0;
        //Go2Point(currentPoint);
        //pointsPatroll = new List<GameObject>();
        StartCoroutine(RoutinePatroll());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Remaining Distance: " + navAgent.remainingDistance + " al punto: " + (nextPoint + 1));
        if (foundPlayer)
        {
            Go2Point(ChickenManager.instance.transform);
        }
    }

    IEnumerator RoutinePatroll()
    {
        yield return new WaitForSeconds(waitInPoint);

        Debug.Log("Current Point: " + nextPoint);
        //Debug.Log("Cantidad de Puntos: " + pointsPatroll.Count);

        if (nextPoint >= points.Length - 1)
        {
            nextPoint = 0;
        }
        else
        {
            nextPoint++;
        }

        navAgent.SetDestination(points[nextPoint].position);

        //Go2Point(currentPoint);


        //while (true)
        //{
        //    //yield return new WaitForSeconds(2);

        //    Debug.Log("Current Point: " + currentPoint);
        //    //Debug.Log("Cantidad de Puntos: " + pointsPatroll.Count);

        //    if (currentPoint >= points.Length - 1)
        //    {
        //        currentPoint = 0;
        //    }
        //    else
        //    {
        //        currentPoint++;
        //    }
            
        //    Go2Point(currentPoint);

        //    yield return new WaitForSeconds(5);

        //}
    }

    public void Go2Point(Transform pos)
    {
        navAgent.SetDestination(pos.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 0)
        {
            StartCoroutine(RoutinePatroll());
        }
        else
        {
            StopAllCoroutines();
            //Go2Point(ChickenManager.instance.transform);
            foundPlayer = true;
        }
        //StopAllCoroutines();
    }
}
