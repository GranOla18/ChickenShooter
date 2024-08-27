using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameManager gM;

    public GameObject terrain;
    Collider terrainCollider;
    public GameObject object2Create;
    Vector3 instancePoint;

    public List<GameObject> createdObjects;

    public int spawnTime;
    public bool enemy;

    // Start is called before the first frame update
    void Start()
    {
        createdObjects = new List<GameObject>();
        StartCoroutine(RoutineInstanceObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RoutineInstanceObject()
    {
        terrainCollider = terrain.GetComponent<Collider>();

        float tiempoTranscurrido = 0;
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            tiempoTranscurrido += Time.deltaTime;

            bool hayObjDesactivados = false;

            for (int i = 0; i < createdObjects.Count; i++)
            {
                if (!createdObjects[i].activeInHierarchy)
                {
                    createdObjects[i].transform.position = GetRandomSpawnPos();
                    createdObjects[i].SetActive(true);
                    hayObjDesactivados = true;
                    break;
                }
            }

            if (!hayObjDesactivados)
            {
                instancePoint = GetRandomSpawnPos();
                if(enemy && createdObjects.Count < 4)
                {
                    createdObjects.Add(Instantiate(object2Create, instancePoint, Quaternion.identity));
                }
                else if (!enemy)
                {
                    createdObjects.Add(Instantiate(object2Create, instancePoint, Quaternion.identity));
                }
            }
            //yield return new WaitForSeconds(spawnTime);
        }
    }

    public Vector3 GetRandomSpawnPos()
    {
        return new Vector3(Random.Range(terrainCollider.bounds.min.x, terrainCollider.bounds.max.x), 0.7f, Random.Range(terrainCollider.bounds.min.z, terrainCollider.bounds.max.z));
    }
}
