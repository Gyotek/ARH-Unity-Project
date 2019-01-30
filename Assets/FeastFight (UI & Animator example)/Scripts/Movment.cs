using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Movment : MonoBehaviour {

    PlayerIndex playerIndex;
    GamePadState gamePad;

    public Animator anim;

    Vector3 lastSpeed = new Vector3();
    Vector3 input;
    Vector3 lastInput;

    // Use this for initialization
    void Start () {
        playerIndex = PlayerManager.instance.playersIndexList[0];
        PlayerManager.instance.playersIndexList.Remove(playerIndex);
    }

    // Update is called once per frame
    void Update () {
        gamePad = GamePad.GetState(playerIndex);

        

        lastInput = input;
        input = new Vector3(gamePad.ThumbSticks.Left.Y, 0, -gamePad.ThumbSticks.Left.X);
        lastSpeed = Vector3.Lerp(lastSpeed, input * Time.deltaTime * PlayerManager.instance.speed, PlayerManager.instance.acceleration * Time.deltaTime);

        if (lastSpeed.magnitude < 0.001)
        {
            lastSpeed = Vector3.zero;
        }

        float playerAngle = Vector3.SignedAngle(transform.forward, lastSpeed.normalized, Vector3.up);
        Vector3 projectedSpeed = Vector3.Project(lastSpeed, transform.forward);

        if (lastInput == Vector3.zero)
        {
            transform.Rotate(new Vector3(0, playerAngle));
        }
        else
        {
            if (Mathf.Abs(playerAngle) > PlayerManager.instance.rotateSpeed)
            {
                if (playerAngle * PlayerManager.instance.rotateSpeed >= 0)
                {
                    playerAngle = PlayerManager.instance.rotateSpeed;
                }
                else
                {
                    playerAngle = -PlayerManager.instance.rotateSpeed;
                }
            }

            transform.Rotate(new Vector3(0, playerAngle) * Time.deltaTime);
        }

        if (projectedSpeed.normalized + transform.forward == Vector3.zero)
        {
            projectedSpeed = -projectedSpeed;
        }

        transform.Translate(projectedSpeed, Space.World);

        anim.SetFloat("Speed", projectedSpeed.magnitude);
    }
}
