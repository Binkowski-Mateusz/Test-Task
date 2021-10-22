using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteNumbers : MonoBehaviour
{
    [SerializeField] private Text textToWrite;
    private string numbers;
    private bool wasShared = false;
    private bool wasUsed = false;
    private bool enabledText;

    public void WriteAndShowNumbers()
    {
        if (!wasUsed)
        {
            for (int counter = 1; counter <= 100; counter++)
            {
                CheckIfIsShareToFiveOrThree(counter);
                wasShared = false;
            }
            wasUsed = true;
            textToWrite.text = numbers;
        }

        enabledText = !enabledText;
        enableTextView(enabledText);
    }

    private void CheckIfIsShareToFiveOrThree(int number)
    {
        if(number % 3 == 0)
        {
            Debug.Log(number);
            numbers = numbers + "Marko";
            wasShared = true;
        }
        if (number % 5 == 0)
        {
            Debug.Log(number);
            numbers = numbers + "Polo";
            wasShared = true;
        }
        if(!wasShared)
        {
            numbers = numbers + number;
        }
    }

    public void enableTextView(bool enable)
    {
        textToWrite.enabled = enable;
    }

}
