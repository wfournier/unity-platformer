using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int currentHealth;

    public IEnumerable<HeartUI> hearts;
    public int totalHealth;

    private void Start()
    {
        hearts = FindObjectsOfType<HeartUI>().OrderBy(h => h.position);
        Update(); // to make sure that the correct amount of health is set at the start (or else totalHealth and currentHealth default at 0)
    }

    private void Update()
    {
        totalHealth = hearts.Count() * (int) HeartState.Full;
        currentHealth = hearts.Sum(h => h.value);
    }

    public void Add(int value)
    {
        Set(currentHealth + value);
    }

    public void Remove(int value)
    {
        Set(currentHealth - value);
    }

    public void Set(int value)
    {
        if (value <= 0)
            currentHealth = 0;
        else if (value >= totalHealth)
            currentHealth = totalHealth;
        else
            currentHealth = value;

        UpdateStates();
    }

    private void UpdateStates()
    {
        var fullHearts =
            (int) Math.Floor(currentHealth /
                             (float) HeartState.Full); // calculate the amount of hearts that need to be full
        var oddHealth = currentHealth % (int) HeartState.Full != 0;

        foreach (var heart in hearts)
            if (heart.position <= fullHearts
            ) // starting from first heart, set to full until amount of full hearts is met
                heart.state = HeartState.Full;
            else if (oddHealth && heart.position == fullHearts + 1
            ) // if amount of health is odd, set the next heart to half
                heart.state = HeartState.Half;
            else // otherwise, set all remaining hearts to empty
                heart.state = HeartState.Empty;
    }
}