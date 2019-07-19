namespace ToyGrafX.Engine.Entities
{
    using OpenTK;

    public class Entity
    {
        public Entity(Model model, Vector3 position, float rotX, float rotY, float rotZ, float scale)
        {
            Model = model;
            Position = position;
            RotX = rotX;
            RotY = rotY;
            RotZ = rotZ;
            Scale = scale;
        }

        public void MoveBy(float dx, float dy, float dz)
        {
            Position = new Vector3(Position.X + dx, Position.Y + dy, Position.Z + dz);
        }

        public void RotateBy(float dx, float dy, float dz)
        {
            RotX += dx;
            RotY += dy;
            RotZ += dz;
        }

        public void ScaleBy(float scale)
        {
            Scale *= scale;
        }

        public Model Model { get; set; }
        public Vector3 Position { get; set; }
        public float RotX { get; set; }
        public float RotY { get; set; }
        public float RotZ { get; set; }
        public float Scale { get; set; }

        //protected abstract string FragmentShaderText { get; }
        //protected abstract string VertexShaderText { get; }
    }
}
