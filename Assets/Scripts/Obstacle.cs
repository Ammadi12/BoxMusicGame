using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float volumeIncreaseAmount = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VolumeManager volumeManager = FindObjectOfType<VolumeManager>();
            if (volumeManager != null)
            {
                volumeManager.IncreaseVolume(volumeIncreaseAmount);
            }
        }
    }
}
