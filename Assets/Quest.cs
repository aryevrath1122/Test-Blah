using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Quest
{
    public string description;
    public Func<PlayerData, bool> successCondition;
    public Func<PlayerData, bool> failureCondition;
    public Action onSuccess;
    public Action onFailure;

    public Quest(string description, Func<PlayerData, bool> successCondition, Action onSuccess,Func<PlayerData, bool> failureCondition = null, Action onFailure = null)
    {
        this.description = description;
        this.successCondition = successCondition;
        this.failureCondition = failureCondition;
        this.onSuccess = onSuccess;
        this.onFailure = onFailure;
    }
}
