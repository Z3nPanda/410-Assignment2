using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    // If player is in trigger range of observer
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    // If player leaves trigger range of observer
    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        // If player is in range cast a ray to determine if they are in the LOS of our observer
        if (m_IsPlayerInRange)
        {
            // Creates a ray to detect if player is in actual line of site
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;

            // If the ray hits something check if its the player
            if(Physics.Raycast(ray, out raycastHit))
            {
                // If we hit the player, we need to end the game since the player was caught
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
