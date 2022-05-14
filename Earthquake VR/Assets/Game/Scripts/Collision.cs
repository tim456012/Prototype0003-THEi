using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Collision : MonoBehaviour
{
    public TeleportPoint teleportPoint;
    public TeleportArea area;
    public TextMeshPro text;
    
    private bool f, s, t;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (f && s && t)
        {
            teleportPoint.locked = false;
            area.locked = false;
            Destroy(text);
            BaseShake.StartShaking = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Object"))
            return;

        switch (other.gameObject.name)
        {
            case "PFB_ChestOfDraws":
                f = true;
                break;
            case "PFB_DiningChair":
                s = true;
                break;
            case "PFB_DiningTable":
                t = true;
                break;
        }
    }
}
