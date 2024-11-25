using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Debug.Log("Game over!");
            Application.Quit(); // עוצר את המשחק במצב Runtime

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // עוצר את המשחק רק ב-Editor
#endif
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
