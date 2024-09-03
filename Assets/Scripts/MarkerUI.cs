using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerUI : MonoBehaviour
{
    public GameObject UIFuseBox;
    private GameObject model = null;
    private bool info = false;
    private bool audioOnOff = false;

    private void Start()
    {
#if !UNITY_EDITOR
        UIFuseBox.SetActive(false);
#endif
    }
    void Update()
    {
        if (model == null)
        {
            model = GameObject.FindGameObjectWithTag("FUSEBOX");
        }
    }

    public void TurnLeft()
    {
        model.GetComponent<Transform>().
            Rotate(new Vector3(15, 0, 0));
    }

    public void TurnRight()
    {
        model.GetComponent<Transform>().
            Rotate(new Vector3(0, 15, 0));
    }

    public void DisplayInfo()
    {
        info = !info;
        model.GetComponentInChildren<Canvas>().enabled = info;
    }

    public void PlayAudio()
    {
        audioOnOff = !audioOnOff;
        if (audioOnOff)
        {
            model.GetComponentInChildren<AudioSource>().Play();
        }
        else
        {
            model.GetComponentInChildren<AudioSource>().Stop();
        }
    }
}
