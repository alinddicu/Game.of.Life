namespace GameOfLife.Classes
{
    public class Cell
    {
        public Cell(uint x, uint y)
        {
            X = x;
            Y = y;
            IsAlive = true;
        }

        public bool IsAlive { get; private set; }

        public uint X { get; private set; }

        public uint Y { get; private set; }

        public override string ToString()
        {
            return string.Format("Cell : {0}, {1}, {2}", X, Y, IsAlive);
        }

        private bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Cell && Equals((Cell)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)X;
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Cell left, Cell right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !left.Equals(right);
        }
    }
}
