﻿namespace ToyGraf.Commands
{
    public class CameraXCommand : ScenePropertyCommand<float>
    {
        public CameraXCommand(float value) : base("CameraLocationX",
            value, s => s._CameraX, (s, v) => s._CameraX = value)
        { }
    }

    public class CameraPitchCommand : ScenePropertyCommand<float>
    {
        public CameraPitchCommand(float value) : base("CameraRotationPitch",
            value, s => s._CameraPitch, (s, v) => s._CameraPitch = value)
        { }
    }

    public class CameraRollCommand : ScenePropertyCommand<float>
    {
        public CameraRollCommand(float value) : base("CameraRotationRoll",
            value, s => s._CameraRoll, (s, v) => s._CameraRoll = value)
        { }
    }

    public class CameraYCommand : ScenePropertyCommand<float>
    {
        public CameraYCommand(float value) : base("CameraLocationY",
            value, s => s._CameraY, (s, v) => s._CameraY = value)
        { }
    }

    public class CameraYawCommand : ScenePropertyCommand<float>
    {
        public CameraYawCommand(float value) : base("CameraRotationYaw",
            value, s => s._CameraYaw, (s, v) => s._CameraYaw = value)
        { }
    }

    public class CameraZCommand : ScenePropertyCommand<float>
    {
        public CameraZCommand(float value) : base("CameraLocationZ",
            value, s => s._CameraZ, (s, v) => s._CameraZ = value)
        { }
    }
}
