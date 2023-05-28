using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Rigidbody _body;

    private bool _isClicked = false;

    public float Speed { get; private set; }
    public float DirectionSpeed { get; private set; }
    public float playerHealth;
    public float playerDamage;

    public event UnityAction PlayerRun;
    public event UnityAction PlayerIdle;
    public event UnityAction PlayerAttack;
    public event UnityAction PlayerFireRifle;
    public event UnityAction PlayerDeath;

    void Start()
    {
        playerHealth = SaveProgress.GetMaxHealth();
        playerDamage = SaveProgress.GetDamage();
        Speed = 4f;
    }

    void Update() {
        MoveAndShootLogic();
        CheckDeath();
    }

    public void MoveAndShootLogic() {
        _body.velocity = new Vector3(_joystick.Vertical * Speed * -1, 0, _joystick.Horizontal * Speed);
        DirectionSpeed = Mathf.Sqrt(_joystick.Vertical * _joystick.Vertical + _joystick.Horizontal * _joystick.Horizontal);

        if (_joystick.Direction.magnitude != 0 && !_isClicked)
        {
            transform.rotation = Quaternion.LookRotation(_body.velocity);
            PlayerRun?.Invoke();
        }
        else if (_joystick.Direction.magnitude == 0 && _isClicked) {
            PlayerAttack?.Invoke();
        }
        else if (_joystick.Direction.magnitude != 0 && _isClicked)
        {
            transform.rotation = Quaternion.LookRotation(_body.velocity);
            PlayerFireRifle?.Invoke();
        }
        else if (_joystick.Direction.magnitude == 0 && !_isClicked)
        {
            PlayerIdle?.Invoke();
        }
    }

    public void StateOnDown() {
        _isClicked = true;
        this.gameObject.transform.rotation *= Quaternion.Euler(0.0f, 45.0f, 0.0f);
    }

    public void StateOnUp() {
        _isClicked = false;
        this.gameObject.transform.rotation *= Quaternion.Euler(0.0f, -45.0f, 0.0f);
    }

    public void MinusHP(float damage) {
        this.playerHealth -= damage;
    }

    public void CheckDeath() {
        if (this.playerHealth <= 0.0f)
        {
            PlayerDeath?.Invoke();
            this.GetComponent<PlayerController>().enabled = false;
        }
    }

    public float GetCurrentHealth() {
        return this.playerHealth;
    }

}
