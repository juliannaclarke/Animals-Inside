using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof (ARTrackedImageManager))]

public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private bool curActive;
    private string prevActive;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject prefab in placeablePrefabs)
        {
            if (prefab.name != "AllAnimals")
            {
                GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                newPrefab.name = prefab.name;
                spawnedPrefabs.Add(prefab.name, newPrefab);
                newPrefab.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
            //all objects are always in updated even if not 'active'
        }
        //foreach (ARTrackedImage trackedImage in eventArgs.removed)
        //{
        //}
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage.referenceImage.name != "AllAnimals")
        {
            string name = trackedImage.referenceImage.name;
            Vector3 position = trackedImage.transform.position;
            Quaternion rotation = trackedImage.transform.rotation;

            GameObject prefab = spawnedPrefabs[name];
            prefab.transform.position = position;
            prefab.transform.rotation = rotation;
            prefab.SetActive(true);
            

            int curAnimalsActive = 0;
            curActive = spawnedPrefabs[name].GetComponent<ActiveAnimal>().isActive;

            foreach (KeyValuePair<string, GameObject> animal in spawnedPrefabs)
            {
                if (animal.Value.GetComponent<ActiveAnimal>().isActive)
                {
                    curAnimalsActive++;
                }
            }

            if (curAnimalsActive == 1 && curActive)
            {
                prevActive = name;
            }
            else if (curAnimalsActive == 2)
            {
                spawnedPrefabs[prevActive].GetComponent<ActiveAnimal>().isActive = false;
            }
        }
    }
}
