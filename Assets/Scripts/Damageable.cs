using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : CollectableObject
{
    public AudioClip damageSFX;

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
        otherObj.GetComponent<IDamage>().Damage();
    }


    public override void SoundPickUp()
    {
        SoundController.instance.audioSource.PlayOneShot(damageSFX);
    }
}
