using RoomClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiMoveJoyStick : Joystick {

    private bool m_bTouch = false;

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        m_bTouch = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        m_bTouch = false;
    }

    private void Update() {
        if (m_bTouch) {
            if(Direction.x < 0) {
                GameClientCommand.Instance.makePlayerMove(MsgPB.PlayerMoveType.Left);
            } else {
                GameClientCommand.Instance.makePlayerMove(MsgPB.PlayerMoveType.Right);
            }
        }
    }
}
