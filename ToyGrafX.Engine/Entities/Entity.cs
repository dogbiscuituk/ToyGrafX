namespace ToyGrafX.Engine.Entities
{
    using OpenTK;

    public class Entity
    {
        public Entity(Model model, Vector3 position, Vector3 rotation, float scale)
        {
            Model = model;
            Position = position;
            Rotation = Rotation;
            Scale = scale;
        }

        public void MoveBy(float dx, float dy, float dz) => Position += new Vector3(dx, dy, dz);
        public void MoveTo(float x, float y, float z) => Position = new Vector3(x, y, z);
        public void RotateBy(float dx, float dy, float dz) => Rotation += new Vector3(dx, dy, dz);
        public void RotateTo(float x, float y, float z) => Rotation = new Vector3(x, y, z);
        public void ScaleBy(float scale) => Scale *= scale;
        public void ScaleTo(float scale) => Scale = scale;

        public Model Model { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public float Scale { get; set; }
    }
}
