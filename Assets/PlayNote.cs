using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayNote : MonoBehaviour
{
    private TMP_Text scoreText;
    public static int score = 0;
    private int pitch = -1;
    private int note = -1;

    void UpdatePitch()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            pitch = 0;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            pitch = 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            pitch = 2;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            pitch = 3;
        }
        else
        {
            pitch = -1;
        }
    }
    void UpdateNote()
    {
        if (Input.GetKey(KeyCode.U))
        {
            if (note % 4 == 0)
            {
                note = 4;
            } else
            {
                note = 0;
            }
        }
        else if (Input.GetKey(KeyCode.I))
        {
            if (note % 4 == 1)
            {
                note = 5;
            }
            else
            {
                note = 1;
            }
        }
        else if (Input.GetKey(KeyCode.O))
        {
            if (note % 4 == 2)
            {
                note = 6;
            }
            else
            {
                note = 2;
            }
        }
        else if (Input.GetKey(KeyCode.P))
        {
            if (note % 4 == 3)
            {
                note = 7;
            }
            else
            {
                note = 3;
            }
        }
        else
        {
            note = -1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject note = collision.gameObject;

        if (!note.CompareTag("Note")) return;

        HitNote(note);
    }

    void HitNote(GameObject noteObj)
    {
        NoteConfig noteConfig = noteObj.GetComponent<NoteConfig>();

        if (note == noteConfig.note && pitch == noteConfig.pitch)
        {
            score += 100;
            Destroy(noteObj);
        }
    }

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePitch();
        UpdateNote();
        scoreText.text = score.ToString();
    }
}
