using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenManager : MonoBehaviour, IPoints, IDamage
{
    public static ChickenManager instance;

    public int score;
    public float health;
    //public Image healthBar;
    //public Gradient gradient;

    public Text scoreTxt;

    public delegate void DamageRecieved(float actualHealth);
    public DamageRecieved onDamageRecieved;

    private void Awake()
    {
        if(instance == null)
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
        health = 1;
    }

    public void GetPoint()
    {
        score += 5;
        scoreTxt.text = "Score: " + score.ToString();
    }

    public void Damage()
    {
        health -= 0.1f;
        //healthBar.fillAmount = health;
        //healthBar.color = gradient.Evaluate(1 - health);
        if (onDamageRecieved != null)
        {
            onDamageRecieved.Invoke(health);
        }
    }

    //public void singletonTest()
    //{
    //    Debug.Log("webos");
    //    if(onDamageRecieved != null)
    //    {
    //        onDamageRecieved.Invoke();
    //    }

    //    // TODO: GLUGLUGLU 
    //}
}

public interface IPoints
{
    void GetPoint();
}

public interface IDamage
{
    void Damage();
}
