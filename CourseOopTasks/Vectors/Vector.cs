using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Vector
    {
        private double[] coordinates;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля");
            }

            coordinates = new double[n];
        }

        public Vector(Vector vector)
        {
            coordinates = (double[])vector.coordinates.Clone();
        }

        public Vector(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля");
            }
            coordinates = (double[])array.Clone();
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля");
            }

            if (n >= array.Length)
            {
                coordinates = new double[n];
                Array.Copy(array, coordinates, array.Length);
            }
            else
            {
                coordinates = new double[n];
                Array.Copy(array, coordinates, n);
            }
        }

        public int GetSize()
        {
            return coordinates.Length;
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", coordinates) + "}";
        }

        public void Addition(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                Array.Resize(ref coordinates, vector.GetSize());
            }

            for (int i = 0; i < vector.GetSize(); i++)
            {
                coordinates[i] += vector.coordinates[i];
            }
        }

        public void Subtraction(Vector vector)
        {
            if (GetSize() < vector.GetSize())
            {
                Array.Resize(ref coordinates, vector.GetSize());
            }

            for (int i = 0; i < vector.GetSize(); i++)
            {
                coordinates[i] -= vector.coordinates[i];
            }
        }

        public void MultiplicationOnScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                coordinates[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplicationOnScalar(-1);
        }

        public double GetLength()
        {
            double intermediateValue = 0;

            foreach (int e in coordinates)
            {
                intermediateValue += Math.Pow(e, 2);
            }

            return Math.Sqrt(intermediateValue);
        }

        public double GetComponentByIndex(int index)
        {
            if (index < 0 || index >= GetSize())
            {
                throw new IndexOutOfRangeException("Выход за размеры вектора!!!");
            }

            return coordinates[index];
        }

        public void SetComponentByIndex(int index, double newValue)
        {
            if (index < 0 || index >= GetSize())
            {
                throw new IndexOutOfRangeException("Выход за размеры вектора!!!");
            }

            coordinates[index] = newValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                if (coordinates[i] != vector.coordinates[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + GetSize();

            foreach (double e in coordinates)
            {
                hash += prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            Vector vectorsSum = new Vector(vector1);
            vectorsSum.Addition(vector2);
            return vectorsSum;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            Vector vectorsDifference = new Vector(vector1);
            vectorsDifference.Subtraction(vector2);
            return vectorsDifference;
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            int min = Math.Min(vector1.GetSize(), vector2.GetSize());
            double scalar = 0;

            for (int i = 0; i < min; i++)
            {
                scalar += vector1.coordinates[i] * vector2.coordinates[i];
            }

            return scalar;
        }
    }
}