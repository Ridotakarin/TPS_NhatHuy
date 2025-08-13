using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ManualShooting : Shooting
{
    [SerializeField] private InputActionReference _shootAction;

    public UnityEvent OnShoot;

    private void Update()
    {
        if (_shootAction.action.triggered)
        {
            Shoot();
        }
    }

    public override void Shoot() => OnShoot.Invoke();
    public override void AmmoCount()
    {

    }
    public override void Reload()
    {

    }
}
