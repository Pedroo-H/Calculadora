namespace Calculator.Operations.Impl
{

    class Division : IOperation {
        
        public Division() : base("Divisão", 2, 2)  {
        
        }

        protected override float Apply(float[] values) {
            if (values[1] == 0) 
            {
                throw new DivideByZeroException("Não é possível fazer a divisão quando o divisor é 0!");
            }

             return values[0]/values[1];
        }
    }
}