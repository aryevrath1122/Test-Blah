using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public class Quest
    {
        public string Description { get; private set; }
        public Func<bool> SuccessCondition { get; private set; }
        public Func<bool> FailureCondition { get; private set; }
        public Action OnSuccess { get; private set; }
        public Action OnFailure { get; private set; }

        public Quest(string description, Func<bool> successCondition, Action onSuccess, Func<bool> failureCondition = null, Action onFailure = null)
        {
            Description = description;
            SuccessCondition = successCondition;
            FailureCondition = failureCondition;
            OnSuccess = onSuccess;
            OnFailure = onFailure;
        }
    }

    private List<Quest> activeQuests = new List<Quest>();

    public void InitialiseQuest(string description, Func<bool> successCondition, Action onSuccess, Func<bool> failureCondition = null, Action onFailure = null)
    {
        var quest = new Quest(description, successCondition, onSuccess, failureCondition, onFailure);
        activeQuests.Add(quest);

        Debug.Log($"Quest Added: {description}");
        StartCoroutine(TrackQuest(quest));
    }

    private IEnumerator TrackQuest(Quest quest)
    {
        while (true)
        {
            if (quest.SuccessCondition())
            {
                Debug.Log($"Quest Succeeded: {quest.Description}");
                quest.OnSuccess?.Invoke();
                activeQuests.Remove(quest);
                yield break;
            }

            if (quest.FailureCondition != null && quest.FailureCondition())
            {
                Debug.Log($"Quest Failed: {quest.Description}");
                quest.OnFailure?.Invoke();
                activeQuests.Remove(quest);
                yield break;
            }

            yield return null;
        }
    }
}
