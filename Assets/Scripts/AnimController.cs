using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    GameObject animals, panel;

    void Start()
    {
        panel = GameObject.Find("BracketLayer");
    }

    void Update()
    {
        animals = GameObject.FindWithTag("TutorialAnimals");
        if (animals != null)
        {
            panel.SetActive(false);

        }
    }
}
