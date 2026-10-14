using UnityEngine;

public class Target : MonoBehaviour 
{ 
    [SerializeField] GameObject boomVFX;
    [SerializeField] int hitPoints = 1;
    [SerializeField] int scoreValue = 100;
 
    public void TakeHit(int damage) 
    { 
        hitPoints -= damage; 

        if (hitPoints <= 0) 
        { 
            GameManager.Instance.AddScore(scoreValue); 
            Destroy(gameObject); 
        } 
    }
    void OnTriggerEnter(Collider other)          // Unity calls this when a bullet hits 
    { 
        Instantiate(boomVFX, transform.position, Quaternion.identity);   // explosion 
        Destroy(other.gameObject);          // remove the bullet 
        Destroy(gameObject);               // remove this target 
    } 
} 