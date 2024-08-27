using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int step = 1;
    Vector3 targetPos;
    public float bulletLife = 0;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step * Time.deltaTime);

        bulletLife += Time.deltaTime;

        if (bulletLife >= 6)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        targetPos = transform.position + transform.forward * 40;
        bulletLife = 0;
    }
}
