﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    AudioManager audioManager;
    public Animator anim;

    void Start()
    {
        audioManager = AudioManager.instance;               // instantiates AudioManager
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found");
        }
    }

    // UI Sound Control ////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]                                        // instantiates field
    string hoverOverSound = "ButtonHover";                  // instantiates Hover Over Sound
    [SerializeField]
    string pressButtonSound = "ButtonPress";                // instantiates Press Button Sound
    [SerializeField]
    string music = "Music";                                 // instantiates title bgm
    [SerializeField]
    string level1_bgm = "Level1_BGM";                       // instantiates Level 1 BGM
    [SerializeField]
    string level2_bgm = "Level2_BGM";                       // instantiates Level 2 BGM
    [SerializeField]
    string level3_bgm = "Level3_BGM";                       // instantiates Level 3 BGM
    [SerializeField]
    string level4_bgm = "Level4_BGM";                       // instantiates Level 4 BGM
    [SerializeField]
    string level5_bgm = "Level5_BGM";                       // instantiates Level 5 BGM
    [SerializeField]
    string level6_bgm = "Level6_BGM";                       // instantiates Level 6 BGM
    [SerializeField]
    string freeRoam = "FreeRoam";                           // instantiates Free Roam BGM
    [SerializeField]
    string credits_bgm = "Credits_BGM";

    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);             // makes a sound when hovering
    }

    public void OnMouseDown()
    {
        audioManager.PlaySound(pressButtonSound);           // makes a sound when pressed
    }

    public void PlayMusic()
    {
        audioManager.PlaySound(music);                      // Plays title bgm
    }

    public void StopMusic()
    {
        audioManager.StopSound(music);                      // Stops title bgm
    }

    public void PlayLevel1_BGM()
    {
        audioManager.PlaySound(level1_bgm);                 // Plays Level 1 bgm
    }

    public void StopLevel1_BGM()
    {
        audioManager.StopSound(level1_bgm);                 // Stops Level 1 bgm
    }

    public void PlayLevel2_BGM()
    {
        audioManager.PlaySound(level2_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel2_BGM()
    {
        audioManager.StopSound(level2_bgm);                 // Stops Level 2 bgm
    }

    public void PlayLevel3_BGM()
    {
        audioManager.PlaySound(level3_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel3_BGM()
    {
        audioManager.StopSound(level3_bgm);                 // Stops Level 2 bgm
    }

    public void PlayLevel4_BGM()
    {
        audioManager.PlaySound(level4_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel4_BGM()
    {
        audioManager.StopSound(level4_bgm);                 // Stops Level 2 bgm
    }

    public void PlayLevel5_BGM()
    {
        audioManager.PlaySound(level3_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel5_BGM()
    {
        audioManager.StopSound(level5_bgm);                 // Stops Level 2 bgm
    }

    public void PlayLevel6_BGM()
    {
        audioManager.PlaySound(level6_bgm);                 // Plays Level 2 bgm
    }

    public void StopLevel6_BGM()
    {
        audioManager.StopSound(level6_bgm);                 // Stops Level 2 bgm
    }

    public void PlayFreeRoam_BGM()
    {
        audioManager.PlaySound(freeRoam);                   // Plays Free Roam bgm
    }

    public void StopFreeRoam_BGM()
    {
        audioManager.StopSound(freeRoam);                   // Stop Free Roam bgm
    }

    // Level BGM Control ///////////////////////////////////////////////////////////////////////////////////

    public void BackToMainMenu()
    {
        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
        audioManager.PlaySound("Music");            // Restarts main menu music
    }

    public void CreditsToMainMenu()
    {
        //     animation.Play(Credits.clip.name);
        //     yield WaitForSeconds(Credits.clip.length + 0);
        //     Application.LoadLevel("Credits");

        SceneManager.LoadScene("TitleScene");        // Reverses the the scene change to go back to Title Scene
        audioManager.StopSound("Credits_BGM");       // Stop playing Credits_BGM
        audioManager.PlaySound("Music");             // Restarts main menu music
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");     // types out ~Quitting Game~
        Application.Quit();             // and quits game
    }
}
