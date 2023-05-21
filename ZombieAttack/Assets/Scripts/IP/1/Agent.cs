using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxAccel;
    public float maxRotation;
    public float maxAngularAccel;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;
    public float priorityThreshold = 0.2f;
    private Dictionary<int, List<Steering>> groups;

    private void Start()
    {
        velocity = Vector3.zero;
        steering = new Steering();
        groups = new Dictionary<int, List<Steering>>();
    }

    public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }

    public void SetSteering(Steering steering, float weight)
    {
        this.steering.linear += weight * steering.linear;
        this.steering.angular += weight * steering.angular;
    }

    public void SetSteering(Steering steering, int priority)
    {
        if (!groups.ContainsKey(priority))
        {
            groups.Add(priority, new List<Steering>());
        }
        groups[priority].Add(steering);
    }

    public void SetSteering(Steering steering, bool pipeline)
    {
        if (!pipeline)
        {
            this.steering = steering;
            return;
        }
    }

    public virtual void Update() {
        if (!this.tag.Equals("Player"))
        {
            Vector3 displacement = velocity * Time.deltaTime;
            orientation += rotation * Time.deltaTime;

            if (orientation < 0.0f)
                orientation += 360.0f;
            else if (orientation > 360.0f)
                orientation -= 360.0f;

            transform.Translate(displacement, Space.World);
            transform.rotation = new Quaternion();
            transform.Rotate(Vector3.up, orientation);
        }
    }

    public virtual void LateUpdate() {
        steering = GetPrioritySteering();
        groups.Clear();

        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if (velocity.magnitude > maxSpeed) {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }

        if (steering.angular == 0.0f) {
            rotation = 0.0f;
        }

        if (steering.linear.sqrMagnitude == 0.0f) {
            velocity = Vector3.zero;
        }

        steering = new Steering();
    }

    private Steering GetPrioritySteering()
    {
        Steering steering = new Steering();
        float sqrThreshold = priorityThreshold * priorityThreshold;
        List<int> gIdList = new List<int>(groups.Keys);
        gIdList.Sort();
        foreach (int gid in gIdList)
        {
            steering = new Steering();
            foreach (Steering singleSteering in groups[gid])
            {
                steering.linear += singleSteering.linear;
                steering.angular += singleSteering.angular;
            }
            if (steering.linear.magnitude > sqrThreshold ||
                    Mathf.Abs(steering.angular) > priorityThreshold)
            {
                return steering;
            }
        }
        return steering;
    }
}
