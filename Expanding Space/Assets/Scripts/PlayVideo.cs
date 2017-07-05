using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

    public MovieTexture video;
    public string goToRoom;
    private AudioSource sound;
    private bool stop;
    private bool operOne = true;
    private bool operTwo = true;
    void Start () {
        GetComponent<RawImage>().texture = video as MovieTexture;
        sound = GetComponent<AudioSource>();
        sound.clip = video.audioClip;
        //check of je de video kan afspelen.
        if (video.isReadyToPlay && operTwo)
        {
            video.Play();
            sound.Play();
            operTwo = false;
        }
    }
	
	void Update () {
        
        //als de video afspeelt en anders geef je aan dat de video stopt.
        if (operOne)
        {
            if (video.isPlaying)
            {
                stop = false;
                operOne = false;
            }
        }
        if (!video.isPlaying && !operTwo || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(goToRoom);
        }

    }
}
