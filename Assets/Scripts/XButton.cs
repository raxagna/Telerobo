using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{

    public void Click()
    {
        Debug.Log("bye!");
        GameObject popUpWindow = this.transform.parent.parent.gameObject;
        Destroy(popUpWindow);

    }

}
