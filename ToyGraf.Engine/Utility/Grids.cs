namespace ToyGraf.Engine.Utility
{
    using OpenTK;
    using System.Collections.Generic;

    public static class Grids
    {
        #region GetVertexCoords() / GetVertices() in 1, 2 or 3 dimensions.

        /// <summary>
        /// Get the X coordinates of all points equally spaces along a line, where -1 <= X <= +1.
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <returns>
        /// (cX+1) floats, being the coordinates of the points on the X axis.
        /// </returns>
        public static IEnumerable<float> GetVertexCoords(int cX)
        {
            for (var i = 0; i <= cX; i++)
                yield return 2f * i / cX - 1;
        }

        /// <summary>
        /// Get the coordinates of all points on a regular 2D XY grid, where -1 <= X,Y <= +1.
        /// Points are returned ordered by X value, then by Y value.
        /// In other words, X varies more slowly, and Y more quickly.
        /// The diagram below shows the return order of the nine vertices in a 3x3 grid (cX=cY=2).
        /// 
        ///          Y
        ///          |
        ///        3 6 9
        ///     ---2 5 8---X
        ///        1 4 7
        ///          |
        ///
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <returns>
        /// 2(cX+1)(cY+1) floats, being the XY coordinates of the points on the grid.
        /// </returns>
        public static IEnumerable<float> GetVertexCoords(int cX, int cY)
        {
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                for (int j = 0; j <= cY; j++)
                {
                    yield return /* X= */ X;
                    yield return /* Y= */ 2f * j / cY - 1;
                }
            }
        }

        /// <summary>
        /// Get the coordinates of all points on a regular 2D XY grid, where -1 <= X,Y <= +1.
        /// Points are returned ordered by X value, then by Y value.
        /// In other words, X varies more slowly, and Y more quickly.
        /// The diagram below shows the return order of the nine vertices in a 3x3 grid (cX=cY=2).
        /// 
        ///          Y
        ///          |
        ///        3 6 9
        ///     ---2 5 8---X
        ///        1 4 7
        ///          |
        ///
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <returns>
        /// (cX+1)(cY+1) Vector2 structs, being the points on the grid.
        /// </returns>
        public static IEnumerable<Vector2> GetVertices(int cX, int cY)
        {
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                for (int j = 0; j <= cY; j++)
                    yield return new Vector2(X, 2f * j / cY - 1);
            }
        }

        /// <summary>
        /// Get the coordinates of all points in a regular 3D XYZ lattice, where -1 <= X,Y,Z <= +1.
        /// Points are returned ordered by X value, then by Y value, and finally by Z value.
        /// In other words, X varies most slowly, and Z most quickly.
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <param name="cZ">The number of steps along the Z axis.</param>
        /// <returns>
        /// 3(cX+1)(cY+1)(cZ+1) floats, being the XYZ coordinates of the points in the lattice.
        /// </returns>
        public static IEnumerable<float> GetVertexCoords(int cX, int cY, int cZ)
        {
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                for (int j = 0; j <= cY; j++)
                {
                    var Y = 2f * j / cY - 1;
                    for (int k = 0; k <= cZ; k++)
                    {
                        yield return /* X= */ X;
                        yield return /* Y= */ Y;
                        yield return /* Z= */ 2f * k / cZ - 1;
                    }
                }
            }
        }

        /// <summary>
        /// Get the coordinates of all points in a regular 3D XYZ lattice, where -1 <= X,Y,Z <= +1.
        /// Points are returned ordered by X value, then by Y value, and finally by Z value.
        /// In other words, X varies most slowly, and Z most quickly.
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <param name="cZ">The number of steps along the Z axis.</param>
        /// (cX+1)(cY+1)(cZ+1) Vector3 structs, being the points in the lattice.
        public static IEnumerable<Vector3> GetVertices(int cX, int cY, int cZ)
        {
            for (var i = 0; i <= cX; i++)
            {
                var X = 2f * i / cX - 1;
                for (int j = 0; j <= cY; j++)
                {
                    var Y = 2f * j / cY - 1;
                    for (int k = 0; k <= cZ; k++)
                        yield return new Vector3(X, Y, 2f * k / cZ - 1);
                }
            }
        }

        #endregion

        #region Get[PrimitiveType]Indices in 2 or 3 dimensions.

        public static IEnumerable<int> GetTriangleIndices(int cX, int cY)
        {
            var p = 0;
            for (var i = 0; i < cX; i++)
            {
                for (var j = 0; j < cY; j++)
                {
                    yield return p;
                    yield return p + cY + 1;
                    p++;
                    yield return p;
                    yield return p;
                    yield return p + cY;
                    yield return p + cY + 1;
                }
                p++;
            }
        }

        /// <summary>
        /// Get the order of vertices required to draw a single continuous triangle strip covering
        /// the grid. This method uses the vertex return order implemented by GetVertexCoords, and
        /// the output is a sequence of alternately ascending and descending strips. For the 6x3
        /// example below (cX=5, cY=2), the 26-element returned sequence is:
        /// 
        ///     00 - 03-01-04-02-05 - 08-04-07-03-06
        ///        - 09-07-10-08-11 - 14-10-03-09-12
        ///        - 15-13-16-14-17
        ///        
        /// To see this, play Snakes & Ladders. Start in the bottom left corner 00, and climb first
        /// up the ladder 03-01-04-02-05, then down the snake 08-04-07-03-06. Now climb back up the
        /// ladder 09-07-10-08-11, and down 14-10-13-09-12. Lastly climb 15-13-16-14-17 and declare
        /// victory. The result describes a single triangle strip, covering the entire grid, though
        /// with degenerate or "null" triangles at 02-05-08, 03-06-09, 08-11-14, and 09-12-15. This
        /// pattern has cX-2 such triangles, so a 1001x1001 grid (cX=cY=1000) will have more than 2
        /// million triangles, less than a thousand of which are degenerate. Hence, any performance
        /// improvement from further grid optimization will be limited to less than 0.05%.
        /// 
        ///     02--05--08--11--14--17
        ///       \    /  \    /  \
        ///        \  /    \  /    \
        ///     01--04--07--10--13--16
        ///       \    /  \    /  \
        ///        \  /    \  /    \
        ///     00--03--06--09--12--15
        /// 
        /// </summary>
        /// <param name="cX">The number of steps along the X axis.</param>
        /// <param name="cY">The number of steps along the Y axis.</param>
        /// <returns>
        /// A total of cX*(2cY+1)+1 ints, ranging from 0 to 3(cX+1)(cY+1)-1 inclusive. These are the
        /// required vertex indices. Note that these must be multiplied by 3 to index the float data
        /// returned by GetVertexCoords, as every such vertex is postprocessed to add a Z coordinate
        /// of zero, and so eventually comprises 3 floats in total.
        /// </returns>
        public static IEnumerable<int> GetTriangleStripIndices(int cX, int cY)
        {
            yield return 0;
            var p = 0;
            for (var i = 0; i < cX; i++)
            {
                for (int j = 0; j < cY; j++)
                {
                    yield return p + cY + 1;
                    yield return (i & 1) == 0 ? ++p : --p;
                }
                yield return p += cY + 1;
            }
        }

        #endregion
    }
}
