namespace ToyGrafX.Engine.Entities
{
    public class Model
    {
        public Model(int vaoID, int vertexCount)
        {
            VaoID = vaoID;
            VertexCount = vertexCount;
        }

        public int VaoID { get; }
        public int VertexCount { get; }
    }
}
