namespace ToyGraf.Commands
{
    public class CameraXCommand : ScenePropertyCommand<float>
    {
        public CameraXCommand(float value) : base("CameraLocationX",
            value, s => s._CameraLocationX, (s, v) => s._CameraLocationX = value)
        { }
    }

    public class CameraPitchCommand : ScenePropertyCommand<float>
    {
        public CameraPitchCommand(float value) : base("CameraRotationPitch",
            value, s => s._CameraRotationPitch, (s, v) => s._CameraRotationPitch = value)
        { }
    }

    public class CameraRollCommand : ScenePropertyCommand<float>
    {
        public CameraRollCommand(float value) : base("CameraRotationRoll",
            value, s => s._CameraRotationRoll, (s, v) => s._CameraRotationRoll = value)
        { }
    }

    public class CameraYCommand : ScenePropertyCommand<float>
    {
        public CameraYCommand(float value) : base("CameraLocationY",
            value, s => s._CameraLocationY, (s, v) => s._CameraLocationY = value)
        { }
    }

    public class CameraYawCommand : ScenePropertyCommand<float>
    {
        public CameraYawCommand(float value) : base("CameraRotationYaw",
            value, s => s._CameraRotationYaw, (s, v) => s._CameraRotationYaw = value)
        { }
    }

    public class CameraZCommand : ScenePropertyCommand<float>
    {
        public CameraZCommand(float value) : base("CameraLocationZ",
            value, s => s._CameraLocationZ, (s, v) => s._CameraLocationZ = value)
        { }
    }
}
