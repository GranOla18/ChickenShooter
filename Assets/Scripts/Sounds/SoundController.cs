using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public delegate void ReproduceSound();
    public ReproduceSound onReproduceSFX;

    public AudioClip[] clipSonido;
    public AudioSource audioSource;

    public AudioMixer mixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReproduceSFX(0);
        }
    }

    public void ReproduceSFX(int indiceClip)
    {
        //audioSource.Play();
        //audioSource.PlayOneShot(clipSonido[indiceClip]);
        if (onReproduceSFX != null)
        {
            onReproduceSFX.Invoke();
        }
    }
}
