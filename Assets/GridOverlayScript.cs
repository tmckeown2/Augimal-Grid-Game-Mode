using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotions
{
    Angry,
    Happy,
    Sad,
    Scared,
    Surprised,
    Annoyed,
    Excited,
    Embarrassed,
    Confused,
    MaxEmotions
};

public class GridOverlayScript : MonoBehaviour {

    public GameObject[] prefabEmotions;
    public GameObject[] prefabEmotionsText;

    public bool imagePrompts;
    public int columns;
    public float xSize;
    public int rows;
    public float ySize;

    public int oddEmotionIndex;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// When the deck is selected, clear the overlay and create a new one
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Loading the overlay");

        // Delete existing clones
        ClearOverlay();

        // Create new clones
        CreateOverlay();
    }

    /// <summary>
    /// Clears emotions from the grid
    /// </summary>
    void ClearOverlay()
    {
        Debug.Log("Clearing the overlay");
        var gameObjects = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
    }

    /// <summary>
    /// Creates emotions as a grid
    /// </summary>
    void CreateOverlay()
    {
        GameObject oddEmotion = null; // Stores the odd emotion to look for in the grid

        // Equal chance for all emotions to be selected
        System.Random rand = new System.Random();

        switch (rand.Next() % (int)Emotions.MaxEmotions)
        {
            case (int)Emotions.Angry:
                oddEmotionIndex = (int)Emotions.Angry;
                break;
            case (int)Emotions.Happy:
                oddEmotionIndex = (int)Emotions.Happy;
                break;
            case (int)Emotions.Sad:
                oddEmotionIndex = (int)Emotions.Sad;
                break;
            case (int)Emotions.Scared:
                oddEmotionIndex = (int)Emotions.Scared;
                break;
            case (int)Emotions.Surprised:
                oddEmotionIndex = (int)Emotions.Surprised;
                break;
            case (int)Emotions.Annoyed:
                oddEmotionIndex = (int)Emotions.Annoyed;
                break;
            case (int)Emotions.Excited:
                oddEmotionIndex = (int)Emotions.Excited;
                break;
            case (int)Emotions.Embarrassed:
                oddEmotionIndex = (int)Emotions.Embarrassed;
                break;
            case (int)Emotions.Confused:
                oddEmotionIndex = (int)Emotions.Confused;
                break;
            default:
                Debug.LogError("Unknown emotion selected");
                return;
        }

        oddEmotion = prefabEmotions[oddEmotionIndex];

        if (imagePrompts)
        {
            // Display the image of emotion to look for
            Vector3 promptPosition = this.transform.position - new Vector3(0, -2.5f);
            GameObject prompt = Instantiate(oddEmotion, promptPosition, Quaternion.identity);
            prompt.tag = "Clone";
        }
        else
        {
            // Display the name of emotion to look for
            Vector3 promptPosition = this.transform.position - new Vector3(0, -2.5f);
            GameObject prompt = Instantiate(prefabEmotionsText[oddEmotionIndex], promptPosition, Quaternion.identity);
            prompt.tag = "Clone";
        }

        // Random position for the odd emotion is selected
        int oddEmotionX = (int)(Random.value * columns);
        int oddEmotionY = (int)(Random.value * rows);

        // Grid is made using the remaining emotions and one of the odd emotions at the random position
        for (int x = 1; x <= columns; ++x)
        {
            for (int y = 0; y < rows; ++y)
            {
                Vector3 position = new Vector3(this.transform.position.x + (x * xSize), this.transform.position.y + (y * ySize), 0);

                GameObject clone;
                if ((x - 1) == oddEmotionX && y == oddEmotionY)
                {
                    // If the clone is at the random position then the odd emotion is cloned
                    clone = Instantiate(oddEmotion, position, Quaternion.identity);
                    clone.tag = "Clone";
                }
                else
                {
                    // If the clone is not at the random position then the other emotions are cloned at random
                    GameObject gridEmotion = null;
                    int emotion;

                    // Loop until the emotion selected for the grid is not the odd emotion
                    // This forces only one of the odd emotions to appear in each grid
                    do
                    {
                        emotion = rand.Next() % (int)Emotions.MaxEmotions;
                    }
                    while (emotion == oddEmotionIndex);

                    // Switch through the emotions to the emotion to be cloned
                    switch (emotion)
                    {
                        case (int)Emotions.Angry:
                            gridEmotion = prefabEmotions[(int)Emotions.Angry];
                            break;
                        case (int)Emotions.Happy:
                            gridEmotion = prefabEmotions[(int)Emotions.Happy];
                            break;
                        case (int)Emotions.Sad:
                            gridEmotion = prefabEmotions[(int)Emotions.Sad];
                            break;
                        case (int)Emotions.Scared:
                            gridEmotion = prefabEmotions[(int)Emotions.Scared];
                            break;
                        case (int)Emotions.Surprised:
                            gridEmotion = prefabEmotions[(int)Emotions.Surprised];
                            break;
                        case (int)Emotions.Annoyed:
                            gridEmotion = prefabEmotions[(int)Emotions.Annoyed];
                            break;
                        case (int)Emotions.Excited:
                            gridEmotion = prefabEmotions[(int)Emotions.Excited];
                            break;
                        case (int)Emotions.Embarrassed:
                            gridEmotion = prefabEmotions[(int)Emotions.Embarrassed];
                            break;
                        case (int)Emotions.Confused:
                            gridEmotion = prefabEmotions[(int)Emotions.Confused];
                            break;
                        default:
                            Debug.LogError("Unknown emotion selected");
                            break;
                    }

                    clone = Instantiate(gridEmotion, position, Quaternion.identity);
                    clone.tag = "Clone";
                    
                }
            }
        }
    }
}
