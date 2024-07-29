namespace Calculator.Operations.Impl
{

    class Subtraction : IOperation {
        
        public Subtraction() : base("Subtração")  {
        
        }

        protected override float Apply(float[] values) {
            return values.Aggregate((n1, n2) => n1 - n2);
        }
    }

}