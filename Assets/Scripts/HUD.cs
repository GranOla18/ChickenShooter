using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image healthBar;
    public Gradient gradient;

    private void Start()
    {
        ChickenManager.instance.onDamageRecieved += ModifyHealth;
    }

    //private void OnEnable()
    //{
    //    if(ChickenManager.instance != null)
    //    {
    //        ChickenManager.instance.onDamageRecieved += ModifyHealth;
    //    }
    //}

    private void OnDisable()
    {
        ChickenManager.instance.onDamageRecieved -= ModifyHealth;
    }

    public void ModifyHealth(float newHealth)
    {
        healthBar.fillAmount = newHealth;
        healthBar.color = gradient.Evaluate(1 - newHealth);
    }
}
