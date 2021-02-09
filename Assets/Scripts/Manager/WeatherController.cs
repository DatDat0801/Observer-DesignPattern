using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeWeather()
    {
        this.PostEvent(e_EventID.weatherChange);
        Debug.Log("Updated Enemy's Attack!!!!");
    }
}
