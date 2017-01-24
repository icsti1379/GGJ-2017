﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class TriggerLightAllColors : MonoBehaviour
{

    bool isLighting;
    bool isUnLighting;
    float lightTime = 0;
    float unLightTime = 0;

    //List<GameObject> redObjects;
    //List<GameObject> blueObjects;
    //List<GameObject> greenObjects;

    [SerializeField]
    float maxLightImpulseTime;
    [SerializeField]
    float LightImpulseIntensity;
    [SerializeField]
    float maxUnlightTime;
    [SerializeField]
    Light pointLight;
    [SerializeField]
    GameObject soundWave;
    [SerializeField]
    float maxSoundTime;

    float soundTime;


    [SerializeField]
    AudioSource impulse;
    [SerializeField]
    AudioSource WaveSoundR;
    [SerializeField]
    AudioSource WaveSoundG;
    [SerializeField]
    AudioSource WaveSoundB;

    private void Start()
    {
        //blueObjects = new List<GameObject>();
        //redObjects = new List<GameObject>();
        //greenObjects = new List<GameObject>();
        //GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        //for (var i = 0; i < objects.Length; i++)
        //{
        //    if (objects[i].layer == 8) //Blue
        //    {
        //        blueObjects.Add(objects[i]);
        //    }
        //}
        //for (var i = 0; i < objects.Length; i++)
        //{
        //    if (objects[i].layer == 9) //Red
        //    {
        //        redObjects.Add(objects[i]);
        //    }
        //}
        //for (var i = 0; i < objects.Length; i++)
        //{
        //    if (objects[i].layer == 10) //Green
        //    {
        //        greenObjects.Add(objects[i]);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
        {
            pointLight.cullingMask = 256;
            pointLight.color = Color.blue;
            soundWave.layer = 11;
            //foreach (GameObject blueObject in blueObjects)
            //{
            //    blueObject.GetComponent<Renderer>().enabled = true;
            //}
            //foreach (GameObject greenObject in greenObjects)
            //{
            //    greenObject.GetComponent<Renderer>().enabled = false;
            //}
            //foreach (GameObject redObject in redObjects)
            //{
            //    redObject.GetComponent<Renderer>().enabled = false;
            //}

        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
        {
            pointLight.cullingMask = 512;
            pointLight.color = Color.red;
            soundWave.layer = 12;
            //foreach (GameObject blueObject in blueObjects)
            //{
            //    blueObject.GetComponent<Renderer>().enabled = false;
            //}
            //foreach (GameObject greenObject in greenObjects)
            //{
            //    greenObject.GetComponent<Renderer>().enabled = false;
            //}
            //foreach (GameObject redObject in redObjects)
            //{
            //    redObject.GetComponent<Renderer>().enabled = true;
            //}
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
        {
            pointLight.cullingMask = 33792;
            pointLight.color = Color.green;
            soundWave.layer = 13;
            //foreach (GameObject blueObject in blueObjects)
            //{
            //    blueObject.GetComponent<Renderer>().enabled = false;
            //}
            //foreach (GameObject greenObject in greenObjects)
            //{
            //    greenObject.GetComponent<Renderer>().enabled = true;
            //}
            //foreach (GameObject redObject in redObjects)
            //{
            //    redObject.GetComponent<Renderer>().enabled = false;
            //}
        }

        if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed && soundTime <= 0)
        {
            soundTime = maxSoundTime;
            Instantiate(soundWave,transform.position, transform.rotation);
            if (soundWave.layer == 11)
                WaveSoundB.Play();
            if (soundWave.layer == 12)
                WaveSoundR.Play();
            if (soundWave.layer == 13)
                WaveSoundG.Play();
        }
        if (soundTime > 0)
            soundTime -= Time.deltaTime;

            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed && isLighting == false && isUnLighting == false)
        {
            isLighting = true;
            impulse.Play();
        }

        if (isLighting)
        {
            if (lightTime >= maxLightImpulseTime)
            {
                isLighting = false;
                isUnLighting = true;
                lightTime = 0;
            }


            pointLight.range += (lightTime * LightImpulseIntensity);


            lightTime += Time.deltaTime;
        }
        else if (isUnLighting)
        {
            if (unLightTime >= maxUnlightTime)
            {
                isUnLighting = false;
                unLightTime = 0;
            }

            pointLight.range -= (maxUnlightTime * unLightTime);

            unLightTime += Time.deltaTime;
        }
    }
}