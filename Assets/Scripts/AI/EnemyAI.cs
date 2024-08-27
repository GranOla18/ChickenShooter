using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent navegationAgent;
    public Transform pointToFollow;
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit choque;
            if (Physics.Raycast(rayo, out choque))
            {
                Debug.LogError("Choco con " + choque.collider + " en el punto: " + choque.point);
                Debug.DrawRay(rayo.origin, rayo.direction * 20, Color.red);

                FollowPoint(choque.point);   
            }
        }

        NavMeshHit choqueNavMesh;
        Debug.Log("El objeto sta cerca de un area de navegación: " + NavMesh.SamplePosition(pointToFollow.position, out choqueNavMesh, 1, 1)) ;

        //FollowPoint();
    }

    /// <summary>
    /// Webos
    /// </summary>
    public void FollowPoint()
    {
        navegationAgent.SetDestination(pointToFollow.position);
    }

    /// <summary>
    /// Este metodo sigue un vector 3 que se defina
    /// </summary>
    /// <param name="point2Follow"></param>
    public void FollowPoint(Vector3 point2Follow)
    {
        navegationAgent.SetDestination(point2Follow);
    }
}
