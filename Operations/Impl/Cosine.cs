namespace Calculator.Operations.Impl 
{

    class Cosine : IOperation
    {
        public Cosine() : base("Coseno", 1, 1)
        {
        }

        protected override float Apply(float[] values)
        {
            return (float) Math.Cos(values[0]);
        }
    }

}