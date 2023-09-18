using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class BloomTick : MonoBehaviour
{
    private int noteTicker = 1;
    private PostProcessVolume volume;
    private Bloom bloom = null;
    private AudioSource audio;
    private bool songStart = false;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();

        if (volume.profile.TryGetSettings(out Bloom volBloom))
        {
            bloom = volBloom;
        }

        GameObject music = GameObject.Find("Music");
        audio = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bloom != null)
        {
            bloom.intensity.value = Mathf.Pow((50 - noteTicker) / 50f, 2) * 10;
        }


        if (noteTicker / 50f >= 60f / LevelConfig.bpm)
        {
            if (!audio.isPlaying && !songStart)
            {
                audio.Play();
                songStart = true;
            }
            else if (!audio.isPlaying)
            {
                SceneManager.LoadScene("ui");
            }

            noteTicker = 1;
        }
        else
        {
            noteTicker++;
        }
    }
}
