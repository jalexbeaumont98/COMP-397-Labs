using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float projectileForce;
    private InputAction fire;

    void Awake()
    {
        fire = InputSystem.actions.FindAction("Player/Fire");
        fire.started += Shoot;
    }

    void OnDisable()
    {
        fire.started -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        print("Fire!");
        GameObject proj = GameObject.Instantiate(bullet, projectileSpawn.position, projectileSpawn.rotation);
        proj.GetComponent<Rigidbody>().AddForce(proj.transform.forward * projectileForce, ForceMode.Impulse);
        Destroy(proj, 1.5f);
    }


}
