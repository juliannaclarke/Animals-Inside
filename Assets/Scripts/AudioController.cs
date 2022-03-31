using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioController : MonoBehaviour
{
	[SerializeField]
	private AudioSource[] clips;
	private ActiveAnimal animal;

	void Update()
	{
		animal = GetComponent<ActiveAnimal>();
		if (animal.isActive)
		{
            if (!clips[2].isPlaying)
            {
				Debug.Log("playing sounds");
				PlayClip("sounds");

				if (animal.firstRead)
				{
					Debug.Log("playing narration");
					PlayClip("narration");
					GetComponent<ActiveAnimal>().firstRead = false;
				}
				else if (animal.timeReached && !animal.done)
				{
					Debug.Log(animal.name + " time reached");
					PlayClip("second");
					GetComponent<ActiveAnimal>().done = true;
				}
			}
		}
		else
		{
			//clips[2].Stop();
            foreach (AudioSource m_audio in clips)
            {
                m_audio.Stop();
            }
        }
	}

	public void PlayClip(string type)
	{
		switch (type)
		{
			case "narration":
				clips[0].Play();
				break;
			case "second":
				clips[1].Play();
				break;
			case "sounds":
				clips[2].Play();
				break;
		}
	}

}
