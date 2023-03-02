namespace The_Abyss_Awaits.input.keyboard_mouse;

public class MouseButton {
    public InputState InputState;
    public MouseButtons MouseButtons;

    public MouseButton(MouseButtons mouseButtons) {
        MouseButtons = mouseButtons;
        InputState = InputState.None;
    }
}