﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralTimer : MonoBehaviour
{
    GameController controller;
    DevController devFunctions;

    double counter = 0;

    void Awake()
    {
        controller = gameObject.GetComponent<GameController>();
        devFunctions = gameObject.GetComponent<DevController>();
    }

    // Update the controls in game steps
    void Update()
    {
        counter = Time.deltaTime;

        elapsedTime(counter);
    }

    void elapsedTime(double timeCounter)
    {
        devFunctions.elapsedTime(timeCounter);
    }
    public void simulateOffLineProgress(DateTime logOut)
    {
        TimeSpan sinceLogOut = getSpanSinceLogOut(logOut);
        double timeCounter = sinceLogOut.TotalSeconds;
        //Debug.Log("Seconds: " + timeCounter);
        elapsedTime(timeCounter);
    }

    TimeSpan getSpanSinceLogOut(DateTime logOut)
    {
        TimeSpan span = TimeSpan.Zero;
        DateTime now = DateTime.Now;                  //maybe call to server later?
        int compare = DateTime.Compare(logOut, now);

        if (compare < 0)                              //Compare if input is correct (log out before current time)
        {
            span = now - logOut;
        }

        Debug.Log("Time elapsed: " + span.ToString());
        return span;
    }

    private void OnDisable()
    {
        float sessionTime = Time.timeSinceLevelLoad;
        Debug.Log("Session lenght of: " + sessionTime);
        //devFunctions.checkSessionProgress(sessionTime);
        //Debug.Log("Times produced register in session: " + controller.sessionTimesProduced);
    }
}
