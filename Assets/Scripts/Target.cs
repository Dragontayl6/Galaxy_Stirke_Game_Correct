using UnityEngine;

public class Target : MonoBehaviour 
{ 
    [SerializeField] GameObject boomVFX;
    [SerializeField] int hitPoints = 1;
    [SerializeField] int scoreValue = 100;

    int startingHitPoints;

    void Awake()
    {
        startingHitPoints = hitPoints;
    }

    public void ResetHitPoints()
    {
        hitPoints = startingHitPoints;
    }
 
    public void TakeHit(int damage) 
    { 
        hitPoints -= damage; 

        if (hitPoints <= 0) 
        { 
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(scoreValue);
            }
            else
            {
                Debug.LogError("No ScoreManager is active in the scene; this target cannot add its score.", this);
            }

            if (boomVFX != null)
            {
                Instantiate(boomVFX, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Assign an explosion prefab to this target's Boom VFX field.", this);
            }

            gameObject.SetActive(false);
        } 
    }
    void OnTriggerEnter(Collider other)          // Unity calls this when a bullet hits 
    { 
        TakeHit(1);
        Destroy(other.gameObject);          // remove the bullet
    } 
} 