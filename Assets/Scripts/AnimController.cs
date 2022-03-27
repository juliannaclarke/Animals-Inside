using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    GameObject animals, panel;

    void Start()
    {
        Debug.Log("anim controller");
        panel = GameObject.Find("BracketLayer");
    }

    // Update is called once per frame
    void Update()
    {
        animals = GameObject.FindWithTag("TutorialAnimals");
        if (animals != null)
        {
            panel.SetActive(false);

        }
    }
}
