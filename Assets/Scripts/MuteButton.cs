using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.Unity;
/*

public class MuteButton : MonoBehaviour
{
    
    public Button button;
    public Sprite OffSprite;
    public Sprite OnSprite;
    bool muted = false;

    public void toggleMute()
    {

        Debug.Log(muted == true ? "Unmute" : "Mute");
        Recorder recorder = FindObjectOfType<Recorder>();

        if (recorder != null)
        {
            recorder.TransmitEnabled = muted;
            
        }
        muted = !muted;

        if (button.image.sprite == OnSprite)
        {
            button.image.sprite = OffSprite;
        }  
        else
        {
            button.image.sprite = OnSprite;
        }

    }
}

*/
