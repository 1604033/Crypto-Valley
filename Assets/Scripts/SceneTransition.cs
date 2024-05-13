using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    // Name of the scene to transition to
    public string targetSceneName;
    public string sceneToLoad;
    
    public string playerObjectName; // Name of the player object

    // Function to handle collision with player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
            Debug.Log("Triggering");
        }
    }
    private void OnCollisionEnter2D(Collision2D otherColider2d)
    {
        /*if (otherColider2d != null && otherColider2d.gameObject.TryGetComponent( out Player player))
        {
          StartCoroutine(_transition.MoveObject(from, to, GameManager.instance.player.gameObject, center) );
        }*/
    }

    // Check for collisions with other objects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified name
        if (collision.gameObject.name == playerObjectName)
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
