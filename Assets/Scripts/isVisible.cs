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
        
        if (distanceFromCam < 0.01) //less than 1cm
        {
            GetComponent<ActiveAnimal>().isActive = false;
            //hide animal
            arCam.cullingMask &= ~(1 << gameObject.layer);
        }
        else if (GeometryUtility.TestPlanesAABB(planes, boundingBox.bounds) && (distanceFromCam < 0.5) && distanceFromCam > 0.01)
        {
            GetComponent<ActiveAnimal>().isActive = true;
            //show animal
            arCam.cullingMask |= (1 << gameObject.layer);
        }
    }
}
