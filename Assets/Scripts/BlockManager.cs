using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //cached referance
    private BlockCounter bc;
    private GameStatus gs;
   
    //config parameters
    private int hitsTaken;
    [SerializeField] Sprite[] sprites;
    private void Start()
    {
        hitsTaken = 0;
        bc = FindObjectOfType<BlockCounter>();
        gs = FindObjectOfType<GameStatus>();
        if (this.tag == "Breakable")
            bc.addBlock();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int maxHits = sprites.Length + 1;
        if (collision.collider.gameObject.tag.Equals("Ball"))
        {
            if(this.tag == "Breakable")
            {
                hitsTaken++;
                if(hitsTaken >= maxHits) 
                    beGoneBlock();
                else
                {
                    nextSprite();
                }
            }
                
        }
    }
    public void nextSprite()
    {
        if(sprites[hitsTaken -1] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[hitsTaken - 1];
        }
        else
        {
            Debug.LogError("Sprite is missing in array " + gameObject.name);
        }
    }
    public void beGoneBlock()
    {
        GetComponent<Rigidbody2D>().freezeRotation = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; //this line makes block freely fall
        GetComponent<BoxCollider2D>().enabled = false;
        gs.addScore();
        bc.removeBlocks();
        Destroy(gameObject, 3f);    //we added this to get rid of unnecessary blocks     
    }
    //or you can just Destroy(gameObject, 1f) to destroy the object within 1 second
}
