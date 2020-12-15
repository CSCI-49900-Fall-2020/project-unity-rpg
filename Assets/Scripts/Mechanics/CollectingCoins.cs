using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip pointsSound;
    // Start is called before the first frame update
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            ScoreManager.instance.ChangeScore(coinValue);
            AudioSource.PlayClipAtPoint(pointsSound, transform.position);
            Destroy(gameObject);
        }
    }
    public void soundsg()
    {
        AudioSource.PlayClipAtPoint(pointsSound, transform.position);
    }

}
