using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float projectileSpeed;
    public float despawnTimer;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTimer);

        // This uses the Sign function to return a -1 or +1 based on the Player's localscale
        // The RoundtoInt command ensures it is a whole number
        int directionSign = Mathf.RoundToInt(Mathf.Sign(GameObject.FindWithTag("Player").transform.localScale.x));

        //takes the DirectionSign variable we made and assigns it to a Vector 2 with a (x and y) value
        direction = new Vector2(directionSign, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * projectileSpeed * Time.deltaTime);
    }
}
