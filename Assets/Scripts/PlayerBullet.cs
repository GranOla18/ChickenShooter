using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : CollectableObject
{
    public override void Collected(Collider otherObj)
    {
        Debug.Log("Hit enemy");
        //ChickenManager.instance.singletonTest();
    }
}
