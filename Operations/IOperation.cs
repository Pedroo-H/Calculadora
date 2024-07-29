namespace Calculator.Operations {
    abstract class IOperation
    {
        public string Name { get; set; }
        public int MinParams { get; set; }
        public int MaxParams { get; set; }

        protected IOperation(string name, int maxParams = -1, int minParams = 2)
        {
            Name = name;
            MaxParams = maxParams;
            MinParams = minParams;
        }

        public float Calculate(float[] values)
        {
            if (values == null || values.Length < MinParams || (MaxParams != -1 && values.Length > MaxParams)) {
                throw new ArgumentException("Value array is null or doesn't meet operation requirements");
            }

            return Apply(values);
        }

        protected virtual float Apply(float[] values) {
            throw new NotImplementedException();
        }
    }
}