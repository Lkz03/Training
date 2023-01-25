namespace Training.Objects
{
    public class Matrix<T>
    {
        private T[][] _matrix;
        
        public Matrix(T[][] matrix) => _matrix = matrix;
    }
}
