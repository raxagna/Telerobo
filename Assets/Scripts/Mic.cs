using UnityEngine;
using UnityEngine.UI;

public class Mic : MonoBehaviour
{
    Manager manager;
    public bool muted = true;
    Button button;

    public Sprite OffSprite;
    public Sprite OnSprite;

    void Start()
    {
        manager = transform.parent.GetComponentInChildren<Manager>();
        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        muted = !muted;

        AudioSource audioSource = manager.activeSkippy.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("", true, 10, 44100);
        audioSource.loop = true;

        if(!muted)
        {
            while(!(Microphone.GetPosition(null) > 0)) { }
            audioSource.Play();
            button.image.color = Color.green;
            button.image.sprite = OnSprite;
        }    
        else
        {
            audioSource.Stop();
            button.image.color = Color.white;
            button.image.sprite = OffSprite;
        }

    }
}
