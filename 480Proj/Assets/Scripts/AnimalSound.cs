using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}

