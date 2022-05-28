using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBar : MonoBehaviour
{
    Manager manager;

    Spawner spawner;
    Button spawnButton;
    public List<Button> buttons;

    TextMeshProUGUI textMeshPro;  

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        manager = transform.parent.GetComponentInChildren<Manager>();

        spawner = transform.parent.GetComponentInChildren<Spawner>();

        spawnButton = spawner.GetComponentInChildren<Button>();

        spawnButton.onClick.AddListener(Spawned);

        foreach (Button button in buttons) button.onClick.AddListener(NotSpawned);

        manager.OnSelected.AddListener(EnableButtons);
    }

    void NotSpawned()
    {
        textMeshPro.SetText("Spwan a Skippy first!");
    }

    void Spawned()
    {
        foreach (Button button in buttons)
        {
            button.onClick.RemoveListener(NotSpawned);
            button.onClick.AddListener(NotSelected);
        }
    }
    void NotSelected()
    {
        textMeshPro.SetText("Select a Skippy first!");
    }

    void EnableButtons()
    {
        foreach (Button button in buttons)
        {
            button.onClick.RemoveListener(NotSelected);
            button.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
        }
    }

}
