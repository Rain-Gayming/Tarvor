using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.SocialPlatforms.Impl;

public class InputManager : MonoBehaviour
{
    public Inputs inputs;
    [BoxGroup("Movement")]
    public Vector2 walk;
    [BoxGroup("Movement")]
    public bool sprint;
    [BoxGroup("Movement")]
    public bool crouch;
    [BoxGroup("Movement")]
    public bool jump;
    [BoxGroup("Movement")]
    public bool lay;

    [BoxGroup("Camera")]
    public Vector2 look;
    [BoxGroup("Camera")]
    public bool rightLean;
    [BoxGroup("Camera")]
    public bool leftLean;

    [BoxGroup("Combat")]
    public bool shoot;
    [BoxGroup("Combat")]
    public bool aim;
    [BoxGroup("Combat")]
    public bool canted;
    [BoxGroup("Combat")]
    public bool reload;
    [BoxGroup("Combat")]
    public bool checkAmmo;
    [BoxGroup("Combat")]
    public bool swapFire;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
    }

    public void Update()
    {
#region Movement
        walk = inputs.Movement.Walk.ReadValue<Vector2>();

        inputs.Movement.Sprint.performed += _ => sprint = true;
        inputs.Movement.Sprint.canceled += _ => sprint = false;

        inputs.Movement.Crouch.performed += _ => crouch = true;
        inputs.Movement.Crouch.canceled += _ => crouch = false;

        inputs.Movement.Jump.performed += _ => jump = true;
        inputs.Movement.Jump.canceled += _ => jump = false;

        inputs.Movement.Lay.performed += _ => lay = true;
        inputs.Movement.Lay.canceled += _ => lay = false;
#endregion

#region Camera
        look = inputs.Camera.Look.ReadValue<Vector2>();

        inputs.Camera.LeftLean.performed += _ => leftLean = true;
        inputs.Camera.LeftLean.canceled += _ => leftLean = false;
        
        inputs.Camera.RightLean.performed += _ => rightLean = true;
        inputs.Camera.RightLean.canceled += _ => rightLean = false;
#endregion

#region Combat

        inputs.Combat.Shoot.performed += _ => shoot = true;
        inputs.Combat.Shoot.canceled += _ => shoot = false;

        inputs.Combat.Aim.performed += _ => aim = true;
        inputs.Combat.Aim.canceled += _ => aim = false;

        inputs.Combat.Canted.performed += _ => canted = true;
        inputs.Combat.Canted.canceled += _ => canted = false;

        inputs.Combat.Reload.performed += _ => reload = true;
        inputs.Combat.Reload.canceled += _ => reload = false;

        inputs.Combat.CheckAmmo.performed += _ => checkAmmo = true;
        inputs.Combat.CheckAmmo.canceled += _ => checkAmmo = false;

        inputs.Combat.SwapFire.performed += _ => swapFire = true;
        inputs.Combat.SwapFire.canceled += _ => swapFire = false;

#endregion
    }
}
