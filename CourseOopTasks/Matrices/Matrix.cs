using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace Matrices
{
    class Matrix
    {
        private Vector[] rows;

        public Matrix(int rows, int columns)
        {
            this.rows = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                this.rows[i] = new Vector(columns);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.rows.Length];
            for (int i = 0; i < matrix.rows.Length; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException("Размер матрицы должен быть больше 0");
            }

            rows = new Vector[array.GetLength(0)];
            Vector vector = new Vector(array.GetLength(1));

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    vector.SetComponentByIndex(j, array[i, j]);
                }

                rows[i] = new Vector(vector);
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException("Размер матрицы должен быть больше 0");
            }
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i].GetSize())
                {
                    max = array[i].GetSize();
                }
            }

            rows = new Vector[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                rows[i] = new Vector(max);
                rows[i].Addition(new Vector(array[i]));
            }
        }

        public int GetColumns()
        {
            return rows.Length;
        }

        public int GetRows()
        {
            return rows[0].GetSize();
        }

        public Vector GetRowByIndex(int index)
        {
            if (index < 0 || index >= GetColumns())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }

            return new Vector(rows[index]);
        }

        public void SetRowByIndex(int index, Vector newRow)
        {
            if (index < 0 || index >= GetColumns())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }
            if (newRow.GetSize() != GetColumns())
            {
                throw new ArgumentException("Размер вектора не совпадает");
            }

            rows[index] = new Vector(newRow);
        }

        public Vector GetColumnByIndex(int index)
        {
            if (index < 0 || index >= GetRows())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }

            Vector vector = new Vector(GetColumns());

            for (int i = 0; i < GetColumns(); i++)
            {
                vector.SetComponentByIndex(i, GetRowByIndex(i).GetComponentByIndex(index));
            }

            return vector;
        }
       
        public void Transpose()
        {
            double intermediateValue;

            for (int i = 0; i < GetColumns(); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    intermediateValue = GetRowByIndex(i).GetComponentByIndex(j);
                    rows[i].SetComponentByIndex(j, GetRowByIndex(j).GetComponentByIndex(i));
                    rows[j].SetComponentByIndex(i, intermediateValue);
                }
            }
        }

        public void MultiplicationOnScalar(double scalar)
        {
            foreach(Vector e in rows)
            {
                e.MultiplicationOnScalar(scalar);
            }            
        }

        public double GetDeterminant()
        {
            if (GetColumns() != GetRows())
            {
                throw new Exception("Матрица не квадратная");
            }

            int matrixDimension = GetRows();

            if (matrixDimension == 1)
            {
                return GetRowByIndex(0).GetComponentByIndex(0);
            }
            else if (matrixDimension == 2)
            {
                return GetRowByIndex(0).GetComponentByIndex(0) * GetRowByIndex(1).GetComponentByIndex(1) - GetRowByIndex(1).GetComponentByIndex(0) * GetRowByIndex(0).GetComponentByIndex(1);
            }
            else
            {
                Matrix matrix = new Matrix(rows);
                double result = 0;
                int j = 0;

                for (int i = 0; i < matrixDimension; i++)
                {
                    result += Math.Pow(-1, i) * GetRowByIndex(i).GetComponentByIndex(j) * GetMinor(matrix, i, j).GetDeterminant();
                }

                return result;
            }
        }

        private static Matrix GetMinor(Matrix matrix, int rows, int columns)
        {
            int matrixDimension = matrix.GetRows();
            Matrix result = new Matrix(matrixDimension - 1, matrixDimension - 1);
            int newRows = 0;

            for (int i = 0; i < matrixDimension; i++)
            {
                if (i == rows)
                {
                    continue;
                }

                int newColumns = 0;

                for (int j = 0; j < matrixDimension; j++)
                {
                    if (j == columns)
                    {
                        continue;
                    }                    
                    result.rows[newRows].SetComponentByIndex(newColumns, matrix.GetRowByIndex(i).GetComponentByIndex(j));
                    newColumns++;
                }

                newRows++;
            }
            
            return result;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            for (int i = 0; i < GetColumns(); i++)
            {
                stringBuilder.Append(rows[i]).Append(", ");
            }
            
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public Vector MultiplicationOnVector(Vector vector)
        {
            if (GetColumns() != vector.GetSize())
            {
                throw new ArgumentException("Не подходящий размер вектора");
            }

            Vector result = new Vector(GetColumns());
            Vector column;            

            for (int i = 0; i < GetRows(); i++)
            {
                column = GetColumnByIndex(i);
                column.MultiplicationOnScalar(vector.GetComponentByIndex(i));
                result.Addition(column);
            }

            return result;           
        }

        public void Addition(Matrix matrix)
        {
            if (GetColumns() != matrix.GetColumns() || GetRows() !=  matrix.GetRows())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            for (int i = 0; i < GetColumns(); i++)
            {
                rows[i].Addition(matrix.rows[i]);
            }
        }

        public void Subtraction(Matrix matrix)
        {
            if (GetColumns() != matrix.GetColumns() || GetRows() != matrix.GetRows())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            for (int i = 0; i < GetColumns(); i++)
            {
                rows[i].Subtraction(matrix.rows[i]);
            }
        }

        public static Matrix Addition(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumns() != matrix2.GetColumns() || matrix1.GetRows() != matrix2.GetRows())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            Matrix matricesSum = new Matrix(matrix1);
            matricesSum.Addition(matrix2);
            return matricesSum;
        }

        public static Matrix Subtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumns() != matrix2.GetColumns() || matrix1.GetRows() != matrix2.GetRows())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            Matrix matricesDifference = new Matrix(matrix1);
            matricesDifference.Subtraction(matrix2);
            return matricesDifference;
        }

        public static Matrix Multiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetRows() != matrix2.GetColumns())
            {
                throw new ArgumentException("Матрицы не подходящего размера");
            }

            Matrix matricesMultiplication = new Matrix(matrix1.GetColumns(), matrix2.GetRows());

            for (int i = 0; i < matrix1.GetColumns(); i++)
            {
                for (int j = 0; j < matrix2.GetRows(); j++)
                {
                    matricesMultiplication.rows[i].SetComponentByIndex(j, Vector.ScalarProduct(matrix1.rows[i], matrix2.GetColumnByIndex(j)));
                }
            }

            return matricesMultiplication;
        }
    }
}