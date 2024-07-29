namespace Calculator.Operations.Impl 
{

    class Tangent : IOperation
    {
        public Tangent() : base("Tangente", 1, 1)
        {
        }

        protected override float Apply(float[] values)
        {
            return (float) Math.Tan(values[0]);
        }
    }

}