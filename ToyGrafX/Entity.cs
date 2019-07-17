namespace ToyGrafX
{
    using OpenTK;

    public abstract class Entity
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

        public Model Model { get; set; }
        protected Vector3 Position { get; set; }
        protected float RotX { get; set; }
        protected float RotY { get; set; }
        protected float RotZ { get; set; }
        protected float Scale { get; set; }

        protected abstract string FragmentShaderText { get; }
        protected abstract string VertexShaderText { get; }
    }
}
