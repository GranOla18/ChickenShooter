using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public List<GameObject> bullets;
    Ray rayo;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            BulletPool();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        rayo.origin = transform.position + new Vector3(0, 1, 0);
        rayo.direction = transform.forward;

        Debug.DrawRay(rayo.origin, rayo.direction * 10, Color.blue);

        
    }

    private void BulletPool()
    {
        bool hayObjDesactivados = false;

        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = rayo.origin;
                bullets[i].transform.rotation = Quaternion.LookRotation(this.transform.forward);
                bullets[i].SetActive(true);
                hayObjDesactivados = true;
                break;
            }
        }

        if (!hayObjDesactivados)
        {
            bullets.Add(Instantiate(bullet, rayo.origin, Quaternion.LookRotation(this.transform.forward)));
        }
    }
}