namespace ToyGraf.Commands
{
    internal class CameraXCommand : ScenePropertyCommand<float>
    {
        internal CameraXCommand(float value) : base("CameraLocationX",
            value, s => s._CameraX, (s, v) => s._CameraX = value)
        { }
    }

    internal class CameraPitchCommand : ScenePropertyCommand<float>
    {
        internal CameraPitchCommand(float value) : base("CameraRotationPitch",
            value, s => s._CameraPitch, (s, v) => s._CameraPitch = value)
        { }
    }

    internal class CameraRollCommand : ScenePropertyCommand<float>
    {
        internal CameraRollCommand(float value) : base("CameraRotationRoll",
            value, s => s._CameraRoll, (s, v) => s._CameraRoll = value)
        { }
    }

    internal class CameraYCommand : ScenePropertyCommand<float>
    {
        internal CameraYCommand(float value) : base("CameraLocationY",
            value, s => s._CameraY, (s, v) => s._CameraY = value)
        { }
    }

    internal class CameraYawCommand : ScenePropertyCommand<float>
    {
        internal CameraYawCommand(float value) : base("CameraRotationYaw",
            value, s => s._CameraYaw, (s, v) => s._CameraYaw = value)
        { }
    }

    internal class CameraZCommand : ScenePropertyCommand<float>
    {
        internal CameraZCommand(float value) : base("CameraLocationZ",
            value, s => s._CameraZ, (s, v) => s._CameraZ = value)
        { }
    }
}
