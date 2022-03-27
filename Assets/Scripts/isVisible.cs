using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisible : MonoBehaviour
{
    public ActiveAnimal activeAnimal;
    Camera arCam;
    public Collider boundingBox;
    public Plane[] planes;
    public bool activate;

    public float distanceFromCam;

    void Start()
    {
        boundingBox = this.GetComponent<Collider>();
        arCam = Camera.main;
    }

    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(arCam);

        float x_sqr = Mathf.Pow((arCam.transform.position.x - transform.position.x), 2);
        float y_sqr = Mathf.Pow((arCam.transform.position.y - transform.position.y), 2);
        float z_sqr = Mathf.Pow((arCam.transform.position.z - transform.position.z), 2);
        distanceFromCam = Mathf.Sqrt(x_sqr + y_sqr + z_sqr);

        if (GeometryUtility.TestPlanesAABB(planes, boundingBox.bounds) && (distanceFromCam < 0.5))
        {
            GetComponent<ActiveAnimal>().isActive = true;
        }
        else
        {
            //Debug.Log("Nothing has been detected");
        }

    }
}
