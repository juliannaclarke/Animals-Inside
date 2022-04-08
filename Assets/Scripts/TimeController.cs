using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float changeTime, currentTime = 0.0f;
    private ActiveAnimal animal;

    void Start()
    {
        changeTime = 35.0f;
    }
    void Update()
    {
        animal = GetComponent<ActiveAnimal>();

        if (animal.isActive && !animal.timeReached)
        {
            currentTime += Time.deltaTime;
        }
        else if (currentTime != 0 && !animal.timeReached)
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= changeTime)
        {
            GetComponent<ActiveAnimal>().timeReached = true;
        }
    }
}
