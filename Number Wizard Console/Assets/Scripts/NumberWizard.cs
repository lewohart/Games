using System;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int min;
    int max;
    int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        min = 1;
        max = 1000;
        guess = 500;

        print("===========================");
        print("Welcome to \"Number Wizard\"!");
        print("Pick a number in your head, but don't tell me!");
        print(String.Format("The lowest number you can pick is {0}", min));
        print(String.Format("The highest number you can pick is {0}", max));
        print(String.Format("Is your number higher or lower than {0}?", guess));
        print("Down = Lower | Up = Higher | Return = Equals");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess - 1;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }
    }

    private void NextGuess()
    {
        guess = (max + min) / 2;
        print(String.Format("Higher or lower than {0}?", guess));
    }
}