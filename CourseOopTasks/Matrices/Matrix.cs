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
        private Vector[] vectorsArray;

        public Matrix(int n, int m)
        {
            vectorsArray = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                vectorsArray[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            vectorsArray = new Vector[matrix.vectorsArray.Length];
            for (int i = 0; i < matrix.vectorsArray.Length; i++)
            {
                vectorsArray[i] = new Vector(matrix.vectorsArray[i]);
            }
        }

        public Matrix(double[,] array)
        {
            vectorsArray = new Vector[array.GetLength(0)];
            Vector vector = new Vector(array.GetLength(1));

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    vector.SetComponentByIndex(j, array[i, j]);
                }

                vectorsArray[i] = new Vector(vector);
            }
        }

        public Matrix(Vector[] array)
        {
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i].GetSize())
                {
                    max = array[i].GetSize();
                }
            }

            vectorsArray = new Vector[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                vectorsArray[i] = new Vector(max);
                vectorsArray[i].Addition(new Vector(array[i]));
            }
        }

        public int GetHeyght()
        {
            return vectorsArray.Length;
        }

        public int GetWidth()
        {
            return vectorsArray[0].GetSize();
        }

        public Vector GetVectorByIndex(int index)
        {
            if (index < 0 || index >= GetHeyght())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }

            return vectorsArray[index];
        }

        public void SetVectorByIndex(int index, Vector newValue)
        {
            if (newValue.GetSize() < GetHeyght() || newValue.GetSize() > GetHeyght())
            {
                throw new ArgumentException("Размер вектора не совпадает");
            }
            vectorsArray[index] = newValue;
        }

        public Vector GetColumnByIndex(int index)
        {
            if (index < 0 || index >= GetWidth())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }
            Vector vector = new Vector(GetHeyght());

            for (int i = 0; i < GetHeyght(); i++)
            {
                vector.SetComponentByIndex(i, GetVectorByIndex(i).GetComponentByIndex(index));
            }

            return vector;
        }

        public void Transpose()
        {
            Matrix transposed = new Matrix(GetWidth(), GetHeyght());

            for (int i = 0; i < GetWidth(); i++)
            {
                transposed.SetVectorByIndex(i, GetColumnByIndex(i));
            }

            vectorsArray = transposed.vectorsArray;
        }

        public void MultiplicationOnScalar(double scalar)
        {
            for (int i = 0; i < GetHeyght(); i++)
            {
                vectorsArray[i].MultiplicationOnScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (GetHeyght() != GetWidth())
            {
                throw new Exception("Матрица не квадратная");
            }

            int matrixDimension = GetWidth();

            if (matrixDimension == 1)
            {
                return GetVectorByIndex(0).GetComponentByIndex(0);
            }
            else if (matrixDimension == 2)
            {
                return GetVectorByIndex(0).GetComponentByIndex(0) * GetVectorByIndex(1).GetComponentByIndex(1) - GetVectorByIndex(1).GetComponentByIndex(0) * GetVectorByIndex(0).GetComponentByIndex(1);
            }
            else
            {
                Matrix matrix = new Matrix(vectorsArray);
                double result = 0;
                int j = 0;
                for (int i = 0; i < matrixDimension; i++)
                {
                    result += Math.Pow(-1, i) * GetVectorByIndex(i).GetComponentByIndex(j) * GetMinor(matrix, i, j).GetDeterminant();
                }
                return result;
            }
        }

        private static Matrix GetMinor(Matrix matrix, int row, int col)
        {
            int matrixDimension = matrix.GetWidth();
            Matrix result = new Matrix(matrixDimension - 1, matrixDimension - 1);
            int newRow = 0;
            for (int i = 0; i < matrixDimension; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int newCol = 0;
                for (int j = 0; j < matrixDimension; j++)
                {
                    if (j == col)
                    {
                        continue;
                    }
                    result.GetVectorByIndex(newRow).SetComponentByIndex(newCol, matrix.GetVectorByIndex(i).GetComponentByIndex(j));
                    newCol++;
                }
                newRow++;
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < GetHeyght(); i++)
            {
                stringBuilder.Append(vectorsArray[i]).Append(", ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            return "{" + stringBuilder.ToString() + "}";
        }

        public Vector MultiplicationOnVector(Vector vector)
        {
            if (GetHeyght() != vector.GetSize())
            {
                throw new ArgumentException("Не подходящий размер вектора");
            }
            Vector column = new Vector(GetHeyght());
            Vector result = new Vector(GetHeyght());

            for (int i = 0; i < GetHeyght(); i++)
            {
                column = GetColumnByIndex(i);
                column.MultiplicationOnScalar(vector.GetComponentByIndex(i));
                result.Addition(column);
            }

            return result;
        }

        public void Addition(Matrix matrix)
        {
            if (GetHeyght() != matrix.GetHeyght() || GetWidth() !=  matrix.GetWidth())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            for (int i = 0; i < GetHeyght(); i++)
            {
                vectorsArray[i].Addition(matrix.vectorsArray[i]);
            }
        }

        public void Subtraction(Matrix matrix)
        {
            if (GetHeyght() != matrix.GetHeyght() || GetWidth() != matrix.GetWidth())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            for (int i = 0; i < GetHeyght(); i++)
            {
                vectorsArray[i].Subtraction(matrix.vectorsArray[i]);
            }
        }

        public static Matrix Addition(Matrix matrix1, Matrix matrix2)
        {
            Matrix matricesSum = new Matrix(matrix1);
            matricesSum.Addition(matrix2);
            return matricesSum;
        }

        public static Matrix Subtraction(Matrix matrix1, Matrix matrix2)
        {
            Matrix matricesDifference = new Matrix(matrix1);
            matricesDifference.Subtraction(matrix2);
            return matricesDifference;
        }

        public static Matrix Multiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetWidth() != matrix2.GetHeyght())
            {
                throw new ArgumentException("Матрицы не подходящего размера");
            }

            Matrix matricesMultiplication = new Matrix(matrix1.GetHeyght(), matrix2.GetWidth());

            for (int i = 0; i < matrix1.GetHeyght(); i++)
            {
                for (int j = 0; j < matrix2.GetWidth(); j++)
                {
                    matricesMultiplication.vectorsArray[i].SetComponentByIndex(j, Vector.ScalarProduct(matrix1.vectorsArray[i], matrix2.GetColumnByIndex(j)));
                }
            }

            return matricesMultiplication;
        }
    }
}