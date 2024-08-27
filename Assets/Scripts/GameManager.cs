using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;
    public ClaseSerializable ejemplo;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }

    [ContextMenu("Convertir a JSON")]
    public void ConvertirAJSON()
    {
        Debug.Log(JsonUtility.ToJson(ejemplo, true));
    }
}

[System.Serializable]
public class ClaseSerializable
{
    public int entero;
    public EstaEsOtraClase[] referencia;
}

[System.Serializable]
public class EstaEsOtraClase
{
    public bool sicierto;
    public float _decimal;
}
