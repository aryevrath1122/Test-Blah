using UnityEngine;

public class TestQuest : MonoBehaviour
{
    private PlayerData playerData;
    private QuestManager questManager;

    private void Start()
    {
        playerData = gameObject.AddComponent<PlayerData>();
        questManager = gameObject.AddComponent<QuestManager>();

        // Test quest 1: Collect 5 resources
        questManager.InitialiseQuest(
            "Collect 5 resources",
            () => playerData.CollectedResources >= 5,
            () => Debug.Log("You collected all resources!"),
            () => playerData.CollectedResources > 10,
            () => Debug.Log("You collected too many resources and failed!")
        );

        // Test quest 2: Defeat 3 enemies
        questManager.InitialiseQuest(
            "Defeat 3 enemies",
            () => playerData.EnemiesDefeated >= 3,
            () => Debug.Log("You defeated all enemies!")
        );
    }

    private void Update()
    {
        // Simulate collecting resources
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerData.CollectedResources++;
            Debug.Log($"Resources collected: {playerData.CollectedResources}");
        }

        // Simulate defeating enemies
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerData.EnemiesDefeated++;
            Debug.Log($"Enemies defeated: {playerData.EnemiesDefeated}");
        }
    }
}
