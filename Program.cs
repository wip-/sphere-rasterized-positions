namespace sphere_rasterized_positions
{
    // TODO use a 3D extended version of Bresenham’s circle drawing algorithm instead
    // Maybe something like this https://stackoverflow.com/questions/9683965/draw-a-sphere-surface-in-voxels-efficiently

    internal class Program
    {
        static bool IsInSphere(int x, int y, int z, double r)
        {
            return x * x + y * y + z * z <= r * r; 
        }

        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../../readme.md"))
            {
                writer.Write("This program generates this readme:");
                
                writer.Write("  ");
                writer.WriteLine();

                for (int slice = 0; slice < 25; slice++)
                {
                    char[,] asciiArt = new char[25, 25];

                    for (int row = 0; row < 25; row++)
                    {
                        for (int col = 0; col < 25; col++)
                        {
                            int x = row - 12;
                            int y = col - 12;
                            int z = slice - 12;
                            if (IsInSphere(x, y, z, 12.5))
                                asciiArt[row, col] = '■';
                            else
                                asciiArt[row, col] = '□';
                        }
                    }

                    writer.Write("  ");
                    writer.WriteLine();

                    writer.Write("Slice " + slice + ":");

                    writer.Write("  ");
                    writer.WriteLine();

                    for (int row = 0; row < 25; row++)
                    {
                        for (int col = 0; col < 25; col++)
                        {
                            writer.Write(asciiArt[row, col]);
                        }
                        writer.Write("  ");
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}