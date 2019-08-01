namespace ToyGraf.Engine.Entities
{
    using OpenTK;

    public class Entity : IEntity
    {
        public Entity(Prototype prototype, Vector3 location, Vector3 rotation, float scale)
        {
            Prototype = prototype;
            Location = location;
            RotationDegrees = rotation;
            Scale = scale;
        }

        public void MoveBy(float dx, float dy, float dz) => Location += new Vector3(dx, dy, dz);
        public void MoveTo(float x, float y, float z) => Location = new Vector3(x, y, z);
        public void RotateBy(float dx, float dy, float dz) => RotationDegrees += new Vector3(dx, dy, dz);
        public void RotateTo(float x, float y, float z) => RotationDegrees = new Vector3(x, y, z);
        public void ScaleBy(float scale) => Scale *= scale;
        public void ScaleTo(float scale) => Scale = scale;

        public Prototype Prototype { get; set; }
        public Vector3 Location { get; set; }
        public Vector3 RotationDegrees { get; set; }
        public float Scale { get; set; }
    }
}
