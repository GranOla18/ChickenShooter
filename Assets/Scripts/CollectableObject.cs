using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collected(other);
        SoundPickUp();
        this.gameObject.SetActive(false);
    }

    public virtual void Collected(Collider otherObj)
    {

    }

    public virtual void SoundPickUp()
    {
        
    }
}
