
namespace triangleArea
{
    class Triangle 
    {
        private int b;
        private int h;
        public double area {get;}

        public Triangle(int b, int h)
        {
            this.b = b;
            this.h = h;
            this.area = this.CalculateArea();
        }

        private double CalculateArea()
        {
            return 0.5 * (this.b * this.h );
        }
    }
}
