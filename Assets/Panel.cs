using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject[] panels; // Array of panels to navigate
    private int currentPanelIndex = 0; // Index of the current active panel

    void Start()
    {
        // Ensure only the first panel is active at the start
        ShowPanel(currentPanelIndex);
    }

    // Function to show a specific panel and hide others
    private void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == index);
        }
        currentPanelIndex = index;
    }

    // Function to navigate to the next panel
    public void NextPanel()
    {
        int nextIndex = (currentPanelIndex + 1) % panels.Length;
        ShowPanel(nextIndex);
    }

    // Function to navigate to the previous panel
    public void PreviousPanel()
    {
        int previousIndex = (currentPanelIndex - 1 + panels.Length) % panels.Length;
        ShowPanel(previousIndex);
    }
}
