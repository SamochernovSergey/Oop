using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Vector
    {
        private int Size;

        public int GetSize()
        {
            return Size;
        }

        private void SetSize(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Размер вектора должен быть больше нуля!!!");
            }
            Size = size;
        }

        private double[] Coordinates;

        public Vector(int n)
        {
            SetSize(n);
            Coordinates = new double[n];
        }

        public Vector(double[] array)
        {
            SetSize(array.Length);
            Coordinates = array;
        }

        public Vector(int n, double[] array)
        {
            SetSize(n);
            if (n > array.Length)
            {
                Coordinates = new double[n];
                for (int i = 0; i < array.Length; i++)
                {
                    Coordinates[i] = array[i];
                }
            }
            else if (n == array.Length)
            {
                Coordinates = array;
            }
            else
            {
                Coordinates = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Coordinates[i] = array[i];
                }
            }
        }

        public Vector(Vector v)
        {
            SetSize(v.GetSize());
            Coordinates = new double[GetSize()];
            for (int i = 0; i < GetSize(); i++)
            {
                Coordinates[i] = v.Coordinates[i];
            }

        }

        public override string ToString()
        {
            return "{" + string.Join(",", Coordinates) + "}";
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() >= vector2.GetSize())
            {
                Vector VectorsSum = new Vector(vector1);
                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    VectorsSum.Coordinates[i] = vector1.Coordinates[i] + vector2.Coordinates[i];
                }
                return VectorsSum;
            }
            else
            {
                Vector VectorsSum = new Vector(vector2);
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    VectorsSum.Coordinates[i] = vector1.Coordinates[i] + vector2.Coordinates[i];
                }
                return VectorsSum;
            }
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {

            if (vector1.GetSize() >= vector2.GetSize())
            {
                Vector VectorsDifference = new Vector(vector1.GetSize());
                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    VectorsDifference.Coordinates[i] = vector1.Coordinates[i] - vector2.Coordinates[i];
                }
                return VectorsDifference;
            }
            else
            {
                Vector VectorsDifference = new Vector(vector2.GetSize());
                Vector VectorsIncrease = new Vector(vector2.GetSize(), vector1.Coordinates);
                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    VectorsDifference.Coordinates[i] = VectorsIncrease.Coordinates[i] - vector2.Coordinates[i];
                }
                return VectorsDifference;
            }
        }

        public static double ScalarProduct(Vector vector1, Vector vector2)
        {
            double scalar = 0;
            if (vector1.GetSize() >= vector2.GetSize())
            {
                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    scalar += vector1.Coordinates[i] * vector2.Coordinates[i];
                }
            }
            else
            {
                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    scalar += vector1.Coordinates[i] * vector2.Coordinates[i];
                }
            }
            return scalar;
        }

        public void VectorsAdition(Vector vector)
        {
            if (GetSize() >= vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    Coordinates[i] = Coordinates[i] + vector.Coordinates[i];
                }
            }
            else
            {
                Vector v = new Vector(vector.GetSize(), Coordinates);
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    v.Coordinates[i] = v.Coordinates[i] + vector.Coordinates[i];
                }
                Coordinates = v.Coordinates;
                SetSize(v.GetSize());
            }
        }

        public void VectorsSubtraction(Vector vector)
        {

            if (GetSize() >= vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    Coordinates[i] = Coordinates[i] - vector.Coordinates[i];
                }
            }
            else
            {
                Vector v = new Vector(vector.GetSize(), Coordinates);
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    v.Coordinates[i] = v.Coordinates[i] - vector.Coordinates[i];
                }
                Coordinates = v.Coordinates;
                SetSize(v.GetSize());
            }
        }

        public void ScalarMultiplication(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Coordinates[i] = Coordinates[i] * scalar;
            }
        }

        public void VectorReversal()
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Coordinates[i] = Coordinates[i] * -1;
            }
        }

        public double VectorLength()
        {
            double length = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                length += Math.Pow(Coordinates[i], 2);
            }
            return Math.Sqrt(length);
        }

        public double GetComponentByIndex(int index)
        {
            if (index <= 0 && index > GetSize())
            {
                throw new ArgumentException("Выход за размеры вектора!!!");
            }

            return Coordinates[index];
        }

        public void SetComponentByIndex(int index, double newValue)
        {
            if (index <= 0 && index > GetSize())
            {
                throw new ArgumentException("Выход за размеры вектора!!!");
            }

            Coordinates[index] = newValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;
            if (Size != vector.GetSize())
            {
                return false;
            }
            for (int i = 0; i < GetSize(); i++)
            {
                if (Coordinates[i] != vector.Coordinates[i])
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
            for (int i = 0; i < GetSize(); i++)
            {
                hash += prime * hash + Coordinates[i].GetHashCode();
            }
            return hash;
        }
    }
}