namespace ToyGrafX
{
    using System.Collections.Generic;
    using System.Linq;

    public class Model
    {
        public Model(int vaoID, int vertexCount)
        {
            VaoID = vaoID;
            VertexCount = vertexCount;

        }

        public int VaoID { get; }
        public int VertexCount { get; }

        public virtual IEnumerable<float> GetVertexCoords() => Enumerable.Empty<float>();
    }
}
