

using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField]
    [Tooltip("How many points to add to the shooter, if the laser hits its target")]
    int pointsToAdd = 1;

    // A reference to the field that holds the score that has to be updated when the laser hits its target.
    NumberField scoreField;

    private void Start()
    {
        // Find the GameObject named "Point" in the scene
        GameObject pointObject = GameObject.Find("ScoreField");

        // Make sure the object was found
        if (pointObject != null)
        {
            // Get the NumberField component attached to the "Point" GameObject
            scoreField = pointObject.GetComponent<NumberField>();
        }
        else
        {
            Debug.LogError("The GameObject 'ScoreField' was not found in the scene!");
        }

        // Check if the scoreField was successfully assigned
        if (!scoreField)
        {
            Debug.LogError($"No NumberField component found on {pointObject.name}!");
        }
    }

    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();  // base = super

        // Modify the text field of the new object;;.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField).SetPointsToAdd(pointsToAdd);

        return newObject;
    }
}