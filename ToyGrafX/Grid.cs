namespace ToyGrafX
{
    using System.Collections.Generic;

    public static class Grid
    {
        #region Public Interface

        /// <summary>
        /// Get the 3D coordinates of all points on a regular 2D grid, where -1 <= x,y <= +1, z = 0.
        /// Points are returned ordered by x value, then by y value, while z is set to a constant 0. 
        /// The diagram below shows the return order of the nine vertices in a 3x3 grid (cx=cy=2).
        /// In this default orthographic projection, the z axis points directly towards you.
        /// 
        ///          y
        ///          |
        ///        2 5 8
        ///     ---1 4 7---x
        ///        0 3 6
        ///          |
        /// 
        /// </summary>
        /// <returns>
        /// A total of 3(cx+1)(cy+1) floats, being the xyz coordinates of the grid, with z=0.
        /// </returns>
        public static IEnumerable<float> GetVertexCoords(int cx, int cy)
        {
            for (var i = 0; i <= cx; i++)
            {
                var x = 2f * i / cx - 1;
                for (int j = 0; j <= cy; j++)
                {
                    yield return /* x= */ 0.9f * (x);
                    yield return /* y= */ 0.9f * (2f * j / cy - 1);
                    yield return /* z= */ 0;
                }
            }
        }

        /// <summary>
        /// Get the order of vertices required to draw a single continuous triangle strip covering
        /// the grid. This method uses the vertex return order implemented by GetVertexCoords, and
        /// the output is a sequence of alternately ascending and descending strips. For the 6x3
        /// example below (CX=5, CY=2), the 26-element returned sequence is:
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
        /// pattern has CX-2 such triangles, so a 1001x1001 grid (CX=CY=1000) will have more than 2
        /// million triangles, less than a thousand of these degenerate.
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
        /// <returns>
        /// A total of CX*(2CY+1)+1 ints, ranging from 0 to 3(CX+1)(CY+1)-1 inclusive. These are the
        /// required vertex indices. Note that these must be multiplied by 3 to index the float data
        /// returned by GetVertexCoords, since each vertex comprises 3 floats.
        /// </returns>
        public static IEnumerable<int> GetTriangleStripIndices(int cx, int cy)
        {
            yield return 0;
            var p = 0;
            for (var i = 0; i < cx; i++)
            {
                for (int j = 0; j < cy; j++)
                {
                    yield return p + cy + 1;
                    yield return (i & 1) == 0 ? ++p : --p;
                }
                yield return p += cy + 1;
            }
        }

        #endregion
    }
}
