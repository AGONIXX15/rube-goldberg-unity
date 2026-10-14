using System.Collections.Generic;
using UnityEngine;

// Counts each distinct pair of machine parts that collide (ground excluded) and shows the total on screen.
public class HitCounter : MonoBehaviour
{
    static readonly HashSet<(GameObject, GameObject)> pairs = new();

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<HitCounter>() == null) return;
        if (!pairs.Contains((c.gameObject, gameObject)) && pairs.Add((gameObject, c.gameObject)))
            Debug.Log($"Golpe {pairs.Count}: {c.gameObject.name} <-> {name}");
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 32;
        GUI.Label(new Rect(20, 20, 400, 50), $"Golpes: {pairs.Count}");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetHits() => pairs.Clear();
}
