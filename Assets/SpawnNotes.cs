using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotes : MonoBehaviour
{
    private int noteTicker = 1;
    public GameObject NotePrefab;
    private AudioSource audio;

    private void Start()
    {
        GameObject music = GameObject.Find("Music");
        audio = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (noteTicker / 50f >= 60f / LevelConfig.bpm)
        {
            if (!audio.isPlaying) return;

            int pitch = Random.Range(0, 4);
            int note = Random.Range(0, 4);

            Vector2 spawnLocation = new Vector2(note, 5.75f);

            GameObject noteObj = Instantiate(NotePrefab);
            noteObj.transform.position = spawnLocation;

            noteObj.tag = "Note";

            SpriteRenderer noteSprite = noteObj.transform.GetComponent<SpriteRenderer>();
            Color color;

            switch (pitch)
            {
                case 0:
                    {
                        color = Color.green; break;
                    }
                case 1:
                    {
                        color = Color.red; break;
                    }
                case 2:
                    {
                        color = Color.blue; break;
                    }
                case 3:
                    {
                        color = Color.yellow; break;
                    }
                default:
                    {
                        color = Color.white; break;
                    }
            }

            noteSprite.color = color;

            NoteConfig noteConfig = noteObj.GetComponent<NoteConfig>();
            noteConfig.pitch = pitch;
            noteConfig.note = note;

            noteTicker = 1;
        }
        else
        {
            noteTicker++;
        }
    }
}
