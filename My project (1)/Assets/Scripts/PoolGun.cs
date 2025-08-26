using UnityEngine;
using UnityEngine.InputSystem;

public class PoolGun : MonoBehaviour
{

    public PoolManager pool;
    public Transform firepoint;

    //called by player input invoke unity events for fire action

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return; // only on press / trigger

        GameObject bullet = pool.GetObject(); // reference gameobject bullet in pool
        if (bullet == null) return; // if you cant get bullet dont do anything (safety check)

        bullet.transform.SetPositionAndRotation(firepoint.position, firepoint.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        if (rb) rb.linearVelocity = firepoint.forward * 20f;
    }
}
