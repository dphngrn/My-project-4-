using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject closeText;

    public AudioSource openSound;
    public AudioSource closeSound;

    public bool Open;
    public bool Closed;
    public bool inReach=false;




    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && Closed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && Open)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Start()
    {
        inReach = false;
        Closed = true;
        Open = false;
        closeText.SetActive(false);
        openText.SetActive(false);
    }

    void Update()
    { 

        if (inReach && Closed && Input.GetButtonDown("Use"))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            openSound.Play();
            Open = true;
            Closed = false;
        }

        else if (inReach && Open && Input.GetButtonDown("Use"))
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeText.SetActive(false);
            closeSound.Play();
            Closed = true;
            Open = false;
        }

    }
}
