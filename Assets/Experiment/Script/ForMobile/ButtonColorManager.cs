using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorManager : MonoBehaviour
{
    // Reference to the Button component
    public Button button;

    // Transparency value (0 is fully transparent, 1 is fully opaque)
    [Range(0, 1)]
    public float alpha = 0.5f;  // Default to 50% transparent

    void Start()
    {
        // Ensure the button component is assigned
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        // Add the listener for the button click
        button.onClick.AddListener(ChangeAlpha);
    }

    // This method is called when the button is clicked
    void ChangeAlpha()
    {
        if (button != null)
        {
            Color color = button.image.color;
            color.a = alpha;
            button.image.color = color;
        }
    }
}

