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
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Размер матрицы должен быть больше 0");
            }

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

            foreach (Vector e in array)
            {
                if (max < e.GetSize())
                {
                    max = e.GetSize();
                }
            }

            rows = new Vector[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                rows[i] = new Vector(max);
                rows[i].Addition(array[i]);
            }
        }

        public int GetRowsNumber()
        {
            return rows.Length;
        }

        public int GetColumnsNumber()
        {
            return rows[0].GetSize();
        }

        public Vector GetRowByIndex(int index)
        {
            if (index < 0 || index >= GetRowsNumber())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }

            return new Vector(rows[index]);
        }

        public void SetRowByIndex(int index, Vector newRow)
        {
            if (index < 0 || index >= GetRowsNumber())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }
            if (newRow.GetSize() != GetColumnsNumber())
            {
                throw new ArgumentException("Размер вектора не совпадает");
            }

            rows[index] = new Vector(newRow);
        }

        public Vector GetColumnByIndex(int index)
        {
            if (index < 0 || index >= GetColumnsNumber())
            {
                throw new IndexOutOfRangeException("Выход за размеры матрицы!!!");
            }

            Vector vector = new Vector(GetRowsNumber());

            for (int i = 0; i < GetRowsNumber(); i++)
            {
                vector.SetComponentByIndex(i, rows[i].GetComponentByIndex(index));
            }

            return vector;
        }

        public void Transpose()
        {
            Vector[] vectors = new Vector[GetColumnsNumber()];

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                vectors[i] = GetColumnByIndex(i);
            }

            rows = vectors;
        }

        public void MultiplicationOnScalar(double scalar)
        {
            foreach (Vector e in rows)
            {
                e.MultiplicationOnScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnsNumber() != GetRowsNumber())
            {
                throw new Exception("Матрица не квадратная");
            }

            int matrixDimension = GetRowsNumber();

            if (matrixDimension == 1)
            {
                return rows[0].GetComponentByIndex(0);
            }
            else if (matrixDimension == 2)
            {
                return rows[0].GetComponentByIndex(0) * rows[1].GetComponentByIndex(1) - rows[1].GetComponentByIndex(0) * rows[0].GetComponentByIndex(1);
            }
            else
            {
                double result = 0;
                int j = 0;

                for (int i = 0; i < matrixDimension; i++)
                {
                    result += Math.Pow(-1, i) * rows[i].GetComponentByIndex(j) * GetMinor(i, j).GetDeterminant();
                }

                return result;
            }
        }
        
        private Matrix GetMinor(int rows, int columns)
        {
            int matrixDimension = GetRowsNumber();
            Matrix resultMinor = new Matrix(matrixDimension - 1, matrixDimension - 1);
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
                    resultMinor.rows[newRows].SetComponentByIndex(newColumns, this.rows[i].GetComponentByIndex(j));
                    newColumns++;
                }

                newRows++;
            }

            return resultMinor;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");

            for (int i = 0; i < GetRowsNumber(); i++)
            {
                stringBuilder.Append(rows[i]).Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public Vector MultiplicationOnVector(Vector vector)
        {
            if (GetColumnsNumber() != vector.GetSize())
            {
                throw new ArgumentException("Не подходящий размер вектора");
            }

            Vector result = new Vector(GetRowsNumber());

            for (int i = 0; i < GetRowsNumber(); i++)
            {
                double coordinate = 0;

                for (int j = 0; j < GetColumnsNumber(); j++)
                {
                    coordinate += rows[i].GetComponentByIndex(j) * vector.GetComponentByIndex(j);
                }

                result.SetComponentByIndex(i, coordinate);
            }

            return result;
        }

        public void Addition(Matrix matrix)
        {
            if (GetColumnsNumber() != matrix.GetColumnsNumber() || GetRowsNumber() != matrix.GetRowsNumber())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                rows[i].Addition(matrix.rows[i]);
            }
        }

        public void Subtraction(Matrix matrix)
        {
            if (GetColumnsNumber() != matrix.GetColumnsNumber() || GetRowsNumber() != matrix.GetRowsNumber())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                rows[i].Subtraction(matrix.rows[i]);
            }
        }

        public static Matrix Addition(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsNumber() != matrix2.GetColumnsNumber() || matrix1.GetRowsNumber() != matrix2.GetRowsNumber())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            Matrix matricesSum = new Matrix(matrix1);
            matricesSum.Addition(matrix2);
            return matricesSum;
        }

        public static Matrix Subtraction(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsNumber() != matrix2.GetColumnsNumber() || matrix1.GetRowsNumber() != matrix2.GetRowsNumber())
            {
                throw new ArgumentException("Матрица не подходящего размера");
            }

            Matrix matricesDifference = new Matrix(matrix1);
            matricesDifference.Subtraction(matrix2);
            return matricesDifference;
        }

        public static Matrix Multiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsNumber() != matrix2.GetRowsNumber())
            {
                throw new ArgumentException("Матрицы не подходящего размера");
            }

            Matrix matricesMultiplication = new Matrix(matrix1.GetRowsNumber(), matrix2.GetColumnsNumber());

            for (int i = 0; i < matrix1.GetRowsNumber(); i++)
            {
                for (int j = 0; j < matrix2.GetColumnsNumber(); j++)
                {
                    matricesMultiplication.rows[i].SetComponentByIndex(j, Vector.ScalarProduct(matrix1.rows[i], matrix2.GetColumnByIndex(j)));
                }
            }

            return matricesMultiplication;
        }
    }
}