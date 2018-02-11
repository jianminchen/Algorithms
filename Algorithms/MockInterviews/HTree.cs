﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * H-Tree Construction
An H-tree is a geometric shape that consists of a repeating pattern resembles the letter “H”.

It can be constructed by starting with a line segment of arbitrary length, drawing two segments of the same length at right angles to the first through its endpoints, and continuing in the same vein, reducing (dividing) the length of the line segments drawn at each stage by √2.

Here are some examples of H-trees at different levels of depth:

        https://www.pramp.com/challenge/EmYgnOgVd4IElnjAnQqn

alt depth = 1

alt depth = 2

alt depth = 3

Write a function drawHTree that constructs an H-tree, given its center (x and y coordinates), a starting length, and depth. Assume that the starting line is parallel to the X-axis.

Use the function drawLine provided to implement your algorithm. In a production code, a drawLine function would render a real line between two points. However, this is not a real production environment, so to make things easier, implement drawLine such that it simply prints its arguments (the print format is left to your discretion).

Analyze the time and space complexity of your algorithm. In your analysis, assume that drawLine's time and space complexities are constant, i.e. O(1).
     * */
    class HTree
    {
        static void drawHTree(double x, double y, double length, int depth)
        {
            if (depth == 0)
            {
                return;
            }

            double x0 = x - length / 2;
            double x1 = x + length / 2;
            double y0 = y - length / 2;
            double y1 = y + length / 2;

            drawLine(x0, y0, x0, y1);
            drawLine(x0, y, x1, y);
            drawLine(x1, y0, x1, y1);

            length = length / 1.414;

            drawHTree(x0, y0, length, depth - 1);
            drawHTree(x0, y1, length, depth - 1);
            drawHTree(x1, y0, length, depth - 1);
            drawHTree(x1, y1, length, depth - 1);
        }

        private static void drawLine(double x0, double y0, double x1, double y1)
        {
            // draws line assume implementation available
        }
    }
}
