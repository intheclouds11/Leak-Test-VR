using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{
    void Start()
    {
        // if i is divisible by 3, print fizz
        // if i is divisible by 5, print buzz

        for (int i = 0; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Debug.Log($"FizzBuzz Bitch! + {i}");
                continue;
            }

            if (i % 3 == 0)
            {
                Debug.Log($"Fizz! + {i}");
            }

            if (i % 5 == 0)
            {
                Debug.Log($"Buzz! + {i}");
            }

            Debug.Log($"Current number: " + i);
        }
    }
}