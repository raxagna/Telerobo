using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newSpawner : MonoBehaviour
{
    GameObject lineup, skippyPrefab;
    public GameObject spawnStation;

    public Color color;

    public Skippy[] skippys = new Skippy[4];
    [HideInInspector] public List<Button> buttons;

    [HideInInspector] public List<Button> switchButtons;
    [HideInInspector] public Button selectButton;
    public Button moveButton;

    string Name;

    Vector3 position;

    int spawnCount = 0;

    void Start()
    {
        skippyPrefab = Resources.Load("Skibby", typeof(GameObject)) as GameObject;

        lineup = transform.parent.parent.transform.GetChild(1).gameObject;

        for (int i = 0; i < 4; i++) buttons.Add(lineup.transform.GetChild(i).GetComponent<Button>());
    }

    public void OnClick()
    {
        Name = $"Skippy {spawnCount + 1}";
        position = spawnStation.transform.GetChild(spawnCount).transform.position;
        
        selectButton = buttons[spawnCount];

        switchButtons = new List<Button>(buttons);
        switchButtons.Remove(switchButtons[spawnCount]);

        skippys[spawnCount] = new Skippy(skippyPrefab, Name, position, color, selectButton, moveButton, switchButtons);

        lineup.transform.GetChild(spawnCount).gameObject.SetActive(true);

        spawnCount++;
    }
}


