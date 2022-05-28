using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skippy
{
    public GameObject skippy;
    public Skippy(GameObject skippy, string name, Vector3 position, Color color, Button selectButton, Button moveButton, List<Button> switchButtons)
    {
        GameObject newSkippy = GameObject.Instantiate(skippy);

        newSkippy.name = name;
        newSkippy.transform.position = new Vector3(position.x, 0.2816933f, position.z);

        SetColor(color, newSkippy);

        newSkippy.GetComponent<SkippyStateManager>().selectButton = selectButton;
        newSkippy.GetComponent<SkippyStateManager>().switchButtons = switchButtons;
        newSkippy.GetComponent<SkippyStateManager>().moveButton = moveButton;

        this.skippy = newSkippy;
    }

    private static void SetColor(Color color, GameObject newSkippy)
    {
        MeshRenderer skippyRenderer = newSkippy.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));

        newMaterial.color = color;
        skippyRenderer.material = newMaterial;
    }
}
