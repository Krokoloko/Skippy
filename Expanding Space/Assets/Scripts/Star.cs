using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Star : MonoBehaviour
{
    public bool used = false;
    private Animator animateStarDeath;
	public GameObject pickupEffect;

    bool markedForDestroy = false;

	public void Used()
	{
		Debug.Log("Im picked up");
		Vector3 position = transform.position;
		Instantiate (pickupEffect, position, Quaternion.identity);
		Destroy (gameObject);
	}

    void Update()
    {
        if (used)
        {
            //Pak de animatie object van de collectable
            animateStarDeath = GetComponentInChildren<Animator>();
            //AnimatorStateInfo stateInfo = animateStarDeath;
            //Speel death animation van de collectable af
            animateStarDeath.SetFloat("speed", 0.2f);
            var info = animateStarDeath.GetCurrentAnimatorStateInfo(0);

            if (!markedForDestroy)
            {
                Destroy(gameObject, info.length);
                markedForDestroy = true;
            }

        }
    }
}
