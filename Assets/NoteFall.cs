using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFall : MonoBehaviour
{
    private readonly float fallSpeed = -8f / (4f * 60f / LevelConfig.bpm) / 50f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.y += fallSpeed;

        transform.position = pos;

        if (transform.position.y < -6)
        {
            PlayNote.score -= 100;
            Destroy(gameObject);
        }
    }
}
