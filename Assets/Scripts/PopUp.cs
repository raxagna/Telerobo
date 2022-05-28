using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class PopUp : MonoBehaviour
{
    GameObject popUp;
    public GameObject vrdetector;

    GameObject Player;
    Transform Camera;

    public string Name;
    public string objectDescription;
    
    public void Click()
    {
        GameObject popUpOn = GameObject.Find("PopupWindow(Clone)");

        if (popUpOn == null)
        {
            popUp = Resources.Load("PopupWindow") as GameObject;
            GameObject popUpWin = Instantiate(popUp) as GameObject;

            bool isVr = vrdetector.GetComponent<VRDetector>().isVr;

            if (isVr == true)
            {
                Player = GameObject.Find("VRPlayer(Clone)");
                Camera = Player.transform.GetChild(0).transform.GetChild(0);

            }
            else
            {
                Player = GameObject.Find("2DPlayer(Clone)");
                Camera = Player.transform.GetChild(0).transform.GetChild(0);

            }

            popUpWin.transform.SetParent(Camera);

            RectTransform rt = popUpWin.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 2);

            GameObject Panel = popUpWin.transform.GetChild(0).gameObject;
            GameObject objectName = Panel.transform.GetChild(0).gameObject;
            GameObject description = Panel.transform.GetChild(1).gameObject;

            Text nameField = objectName.GetComponentInChildren<Text>();
            Text descriptionField = description.GetComponentInChildren<Text>();

            SetText(nameField, Name);
            SetText(descriptionField, objectDescription);

        }
        else
        {
            Debug.Log("There is already a pop up window open");
        }
        
    }

    public void SetText(Text TextField, string text)
    {
        TextField.text = text;
    }
    

}
