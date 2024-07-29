namespace Calculator.Operations.Impl
{
    class SquaredRoot : IOperation {
        
        public SquaredRoot() : base("Raiz Quadrada", 1, 1)  {
        }

        protected override float Apply(float[] values) {
            return (float) Math.Sqrt(values[0]);
        }
    }
}  