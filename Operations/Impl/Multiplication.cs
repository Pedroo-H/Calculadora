namespace Calculator.Operations.Impl
{
    class Multiplication : IOperation {
        
        public Multiplication() : base("Multiplicação")  {
        }

        protected override float Apply(float[] values) {
            return values.Aggregate((n1, n2) => n1 * n2);
        }
    }
}