using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public KeyCode[] sampleKeys;
    public KeyCode[] myKeys;
    int currentKey;
    int verticle;
    int horizontal;
    // Debug And For Sample Below One Line
    public Text[] displaykeys;
    void Start()
    {
        generateKey(4);
    }
    void Update()
    {
        // All if are for movements
        if (Input.GetKeyDown(myKeys[0]))  // UP
        {
            verticle = 1;
           
        }
        if (Input.GetKeyUp(myKeys[0]))  // UP CLOSE
        {
            verticle = 0;
            
        }
        if (Input.GetKeyDown(myKeys[2]))   // RIGHT
        {
            horizontal = 1;
        }
        if (Input.GetKeyUp(myKeys[2]))  // RIGHT CLOSE
        {
            horizontal = 0;
        }

        if (Input.GetKeyDown(myKeys[3]))  // LEFT
        {
            horizontal = -1;
        }
        if (Input.GetKeyUp(myKeys[3]))   // LEFT CLOSE
        {
            horizontal = 0;
        }

        if (Input.GetKeyDown(myKeys[1]))   // DOWN
        {
            verticle = -1;
        }
        if (Input.GetKeyUp(myKeys[1]))    // DOWN CLOSE
        {
            verticle = 0;
        }
        transform.Translate(new Vector2(horizontal, verticle) * 100 * Time.deltaTime);
    }
   
    public void generateKey( int nodeCharCount)
    {
        //Shuffle our arrays first so that every time we get a random key
        shuffleArray<KeyCode>(sampleKeys);
       
        int  alpIndex = 0;
        
        for (int j = 0; j < nodeCharCount; j++)
        {
            myKeys[currentKey] = sampleKeys[alpIndex];
            // Debug And For Sample Below One Line
            displaykeys[currentKey].text = displaykeys[currentKey].text + myKeys[currentKey].ToString();


            currentKey++;
            alpIndex++;

        }
       
    }

    static void shuffleArray<T>(T[] arr)
    { // This will not create a new array but return the original but shuffled array
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
