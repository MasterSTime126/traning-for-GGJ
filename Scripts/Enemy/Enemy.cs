using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour {
    LinkedList<UnityEngine.Vector2> playerpos = new LinkedList<UnityEngine.Vector2>();
    [SerializeField]Transform target;

    private void FixedUpdate() {
        playerpos.AddLast(new UnityEngine.Vector2(target.position.x, target.position.y));
        if(playerpos.Count == 181)
        {
            transform.position = new UnityEngine.Vector3(playerpos.First.Value.x, playerpos.First.Value.y, 0);
            playerpos.RemoveFirst();
        }
    }
}