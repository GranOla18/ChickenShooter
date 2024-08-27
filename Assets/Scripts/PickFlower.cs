using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlower : CollectableObject
{
    public AudioClip coinSFX;

    private void Start()
    {
        SoundController.instance.onReproduceSFX += SoundPickUp;    
    }

    private void OnDisable()
    {
        SoundController.instance.onReproduceSFX -= SoundPickUp;
    }

    public override void Collected(Collider otherObj)
    {
        otherObj.GetComponent<IPoints>().GetPoint();
        //SoundPickUp();
        //Debug.Log("Cola");
    }

    public override void SoundPickUp()
    {
        SoundController.instance.audioSource.PlayOneShot(coinSFX);
    }


    //public void SoundPickUp()
    //{
    //    SoundController.instance.audioSource.PlayOneShot(coinSFX);
    //}
}
