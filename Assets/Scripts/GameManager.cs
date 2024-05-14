using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player; 

    //Pickup and Level Completion logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    public Text pickupText;

    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    public void levelCompleteCheck(){

        if(currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }

    public void UpdateGUI(){
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    //loop for playing audio proximity events - AudioSource based
    public void PlayAudioSamples(){
        for(int i = 0; i < audioSources.Length; i++){
            if(Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity){
                // following if statement accounts for the game loop ie restarting the sound every frame, so fixes o not play over itself
                if(!audioSources[i].isPlaying){
                    audioSources[i].Play();
                }
            }
        }
    }
}
