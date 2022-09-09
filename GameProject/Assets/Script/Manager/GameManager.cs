using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    
    private static int score;
    public static int Score { get => score; set => score = value; }

    public Text ammoText;

    public static GameManager instance { get; private set; }
    
    public int gunAmmo = 8;

    public Text healtText;

    public int healt = 10;

    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {   
            instance = this;
            Debug.Log(instance);
            score = 0;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }

        instance = this;

    }

    private void update()
    {
        ammoText.text = gunAmmo.ToString();
        healtText.text = healt.ToString();
    }

    
}
