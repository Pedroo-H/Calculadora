namespace Calculator.Operations.Impl 
{

    class Sine : IOperation
    {
        public Sine() : base("Seno", 1, 1)
        {
        }

        protected override float Apply(float[] values)
        {
            return (float) Math.Sin(values[0]);
        }
    }

}