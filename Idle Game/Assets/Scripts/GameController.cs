﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text Coins;
    public Slider GameProgress;

    public long coins;
    public long initialReward = 50;             //Coin reward for completing game
    public long reward;
    private long rewardIncrease = 25;

    public float progress;                     //game progress points     
    private float max;                         //progress points to complete a game  
    private float initialMax = 10;                
    private float maxScaleFactor = 0.2f;

    public int gameCounter;                    //How many games have been completed
    // Start is called before the first frame update
    void Start()
    {
        max = initialMax;
        reward = initialReward;
        coins = 0;
        progress = 0;
        gameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Coins.text = "Coins: " + coins;
        //progress++;
        actualizarSlider(max, progress);
    }

    public void addProgress(float prog)
    {
        progress += prog;
    }

    private void actualizarSlider(float mx, float prog)
    {
        float porcentaje;
        porcentaje = prog / mx;
        if (porcentaje >= 1)
        {
            do
            {
                completeGame();
                progress = 0;              //Variable stored, not the parameter
                porcentaje -= 1;
            } while (porcentaje >= 1);
        }
        GameProgress.value = porcentaje;
    }

    //Cualquier cosa que hagamos al completar un juego
    private void completeGame()
    {
        coins += reward;
        gameCounter++;
        scaleMaxProd();
        scaleReward();
    }

    private void scaleMaxProd()
    {
        if(max <= 1)
        {
            max = initialMax;
        }
        else
        {
            max += max * maxScaleFactor;
        }
    }

    private void scaleReward()
    {
        reward += rewardIncrease;
    }
}
