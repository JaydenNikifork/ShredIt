using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretVisual : MonoBehaviour
{
    private SpriteRenderer sprite;
    private int pitch;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (name == "FretQ") pitch = 0;
        else if (name == "FretW") pitch = 1;
        else if (name == "FretE") pitch = 2;
        else if (name == "FretR") pitch = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch (pitch)
        {
            case 0:
                if (Input.GetKey(KeyCode.Q))
                {
                    Color newColor = sprite.color;
                    print(newColor);
                    newColor.g = 0.5f;
                    sprite.color = newColor;
                }
                else
                {
                    sprite.color = Color.green;
                }
                break;
            case 1:
                if (Input.GetKey(KeyCode.W))
                {
                    Color newColor = sprite.color;
                    newColor.r = 0.5f;
                    sprite.color = newColor;
                }
                else
                {
                    sprite.color = Color.red;
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.E))
                {
                    Color newColor = sprite.color;
                    newColor.b = 0.5f;
                    sprite.color = newColor;
                }
                else
                {
                    sprite.color = Color.blue;
                }
                break;
            case 3:
                if (Input.GetKey(KeyCode.R))
                {
                    Color newColor = sprite.color;
                    newColor.r = 0.5f;
                    newColor.g = 0.5f;
                    sprite.color = newColor;
                }
                else
                {
                    sprite.color = Color.yellow;
                }
                break;
        }
    }
}
