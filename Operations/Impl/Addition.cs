namespace Calculator.Operations.Impl
{

    class Addition : IOperation {
        
        public Addition() : base("Adição")  {
        
        }

        protected override float Apply(float[] values) {
            return values.Sum();
        }
    }

}