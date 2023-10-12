using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public GameObject content;
    public float desiredHeightPercentage = 0.75f; // (0.75 for 75% of the screen height)
    public int numberOfSlots = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float desiredHeight = screenHeight * desiredHeightPercentage;

        float newHeight = Mathf.Min(desiredHeight, desiredHeight / numberOfSlots);

        float width = content.GetComponent<RectTransform>().rect.width - 100;
        float aspectRatio = width / content.GetComponent<GridLayoutGroup>().cellSize.y;
        float newWidth = newHeight * aspectRatio;

        Vector2 newSize = new Vector2(newWidth, newHeight);
        content.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
