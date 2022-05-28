using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    int spawnCount = 0;
    GameObject lineup;

    [HideInInspector]
    public List<GameObject> skippyList;

    Button button;

    Vector3 position;

    Manager manager;

    public UnityEvent OnSpawn;

    private void Start()
    {
        manager = transform.parent.parent.GetComponentInChildren<Manager>();
        lineup = manager.gameObject;
        skippyList = new List<GameObject>();
        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        lineup.SetActive(true);

        if (spawnCount < 4)
        {
            lineup.transform.GetChild(spawnCount).gameObject.SetActive(true);

            switch (spawnCount)
            {
                case 0:
                    position = new Vector3(-4, 0.2073223f, -15);
                    break;
                case 1:
                    position = new Vector3(-2, 0.2073223f, -15);
                    break;
                case 2:
                    position = new Vector3(0, 0.2073223f, -15);
                    break;
                case 3:
                    position = new Vector3(2, 0.2073223f, -15);
                    break;
            }

            GameObject skippyItem = Instantiate(Resources.Load("Skippy", typeof(GameObject))) as GameObject;
            skippyItem.transform.position = position;
            skippyItem.name = $"Skippy {spawnCount}";
            skippyItem.GetComponent<PlayerInput>().DeactivateInput();

            skippyList.Add(skippyItem);
            manager.skippyList = skippyList;
        }
        else
        {
            /*
            ColorBlock cb = button.colors;
            cb.pressedColor = Color.red;
            button.colors = cb;
            */
            ControlPanel.ChangeButtonColor(button, false);

            Debug.Log("Max number of Skippys is spawned");
        }

        spawnCount++;

    }

}
