using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    Ray rayo;
    Vector3 playerPos;

    // Start is called before the first frame update
    public GameObject bullet;
    public List<GameObject> bullets;

    void Start()
    {
        bullets = new List<GameObject>();
        playerPos = GameObject.FindObjectOfType<ChickenManager>().transform.position;
    }

    private void FixedUpdate()
    {
        playerPos = GameObject.FindObjectOfType<ChickenManager>().transform.position;
        
        rayo.origin = transform.position + new Vector3(0,1,0);
        rayo.direction = transform.forward;

        Debug.DrawRay(rayo.origin, rayo.direction * 10, Color.blue);
        transform.LookAt(playerPos);
    }

    IEnumerator RoutineEnemyShoot()
    {
        while (this.gameObject.activeInHierarchy)
        {
            bool hayObjDesactivados = false;

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy && this.gameObject.activeInHierarchy)
                {
                    bullets[i].transform.position = rayo.origin;
                    bullets[i].transform.rotation = Quaternion.LookRotation(this.transform.forward);
                    bullets[i].SetActive(true);
                    hayObjDesactivados = true;
                    break;
                }
            }

            if (!hayObjDesactivados && this.gameObject.activeInHierarchy)
            {
                bullets.Add(Instantiate(bullet, rayo.origin, Quaternion.LookRotation(this.transform.forward)));
            }

            yield return new WaitForSeconds(2);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(RoutineEnemyShoot());
        rayo.origin = transform.position + new Vector3(0, 1, 0);
        rayo.direction = transform.forward;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
