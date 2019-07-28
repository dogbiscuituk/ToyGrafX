namespace ToyGraf.Commands
{
    public class CameraLocationXCommand : ScenePropertyCommand<float>
    {
        public CameraLocationXCommand(float value) : base("CameraLocationX",
            value, s => s._CameraLocationX, (s, v) => s._CameraLocationX = value)
        { }
    }

    public class CameraLocationYCommand : ScenePropertyCommand<float>
    {
        public CameraLocationYCommand(float value) : base("CameraLocationY",
            value, s => s._CameraLocationY, (s, v) => s._CameraLocationY = value)
        { }
    }

    public class CameraLocationZCommand : ScenePropertyCommand<float>
    {
        public CameraLocationZCommand(float value) : base("CameraLocationZ",
            value, s => s._CameraLocationZ, (s, v) => s._CameraLocationZ = value)
        { }
    }

    public class CameraRotationPitchCommand : ScenePropertyCommand<float>
    {
        public CameraRotationPitchCommand(float value) : base("CameraRotationPitch",
            value, s => s._CameraRotationPitch, (s, v) => s._CameraRotationPitch = value)
        { }
    }

    public class CameraRotationRollCommand : ScenePropertyCommand<float>
    {
        public CameraRotationRollCommand(float value) : base("CameraRotationRoll",
            value, s => s._CameraRotationRoll, (s, v) => s._CameraRotationRoll = value)
        { }
    }

    public class CameraRotationYawCommand : ScenePropertyCommand<float>
    {
        public CameraRotationYawCommand(float value) : base("CameraRotationYaw",
            value, s => s._CameraRotationYaw, (s, v) => s._CameraRotationYaw = value)
        { }
    }
}
