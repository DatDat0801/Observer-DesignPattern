using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int attack;

    public int atUp;
    void Start()
    {
        this.RegisterListener(e_EventID.weatherChange,(param)=> WeatherAffect(atUp));
    }

    private void WeatherAffect(int at)
    {
        attack += at;
    }    
}
