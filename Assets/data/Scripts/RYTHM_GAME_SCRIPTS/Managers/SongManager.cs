using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    
    //En segons, que tan incorrecte pots donar la nota
    public double marginOfError; 

    public int inputDelayInMilliseconds;
    public bool songEnded;
    public string fileLocation;
    
    //Quant de temps la nota estará en pantalla
    public float noteTime;
    
    //En que posició de Y spawnea la nota
    public float noteSpawnY;
    
    //On se suposa que hauría de ser pulsada la nota
    public float noteTapY;
 
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    void Awake()
    {
        Instance = this;
    }
    
    public static MidiFile midiFile;
    
    void Start()
    {
        ReadFromFile();
    }
    

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        audioSource.Play();
    }
    public static double GetAudioSourceTime()
    {
        //Retorna la posició actual de la cançó en double, podria ser audioSource.time pero per temes de presició se fa un cast a double
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    void Update()
    {
        if (!songEnded)
        {
            CheckSongEnd();
        }
        else
        {
            SongEnded();
        }
    }

    void CheckSongEnd()
    {
        double audioTime = GetAudioSourceTime();
        
        if (audioTime >= audioSource.clip.length)
        {
            songEnded = true;
            SongEnded();
        }
    }
    
    void SongEnded()
    {
        GameEndingManager.Instance.startGameEnd();
    }

}