using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioSource music;
    public float maxVolume = 4f;
    public float volumeDecayRate = 0.5f; 
    public float currentVolume = 1f; 
    private float decayTimer = 0f;
    //private float decayInterval = 4f;
    public Slider VolumeSlider;
    public Image fill;
    public Gradient sliderrad;

    void Start()
    {
        music.volume = currentVolume / maxVolume;
        if (VolumeSlider != null)
        {
            VolumeSlider.maxValue = maxVolume; 
            VolumeSlider.value = currentVolume; 
        }
        UpdateSliderColor();
    }

    void Update()
    {
       
        decayTimer -= Time.deltaTime;
        if (decayTimer <= 0f)
        {
            DecreaseVolume();
            decayTimer = Random.Range(4f, 10f);
        }

        if (VolumeSlider != null)
        {
            VolumeSlider.value = currentVolume;
        }
        UpdateSliderColor();
    }

    
    private void DecreaseVolume()
    {
        currentVolume -= volumeDecayRate;
        currentVolume = Mathf.Clamp(currentVolume, 0, maxVolume);
        music.volume = currentVolume / maxVolume;

        if (currentVolume <= 0)
        {
            
            Debug.Log("Volume has reached 0");
        }

        UpdateSliderColor();
    }

    public void IncreaseVolume(float amount)
    {
        currentVolume += amount;
        currentVolume = Mathf.Clamp(currentVolume, 0, maxVolume);

        music.volume = currentVolume / maxVolume;

       
        if (currentVolume >= maxVolume)
        {
            FindObjectOfType<GameManager>().LoseGame();
        }

        UpdateSliderColor();
    }

    public float GetCurrentVolume()
    {
        return currentVolume;
    }

    private void UpdateSliderColor()
    {
        if (fill != null)
        {
           
            fill.color = sliderrad.Evaluate(currentVolume / maxVolume);
        }
    }
}