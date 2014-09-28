namespace GameOfLife.Classes
{
    public class Cell
    {
        public Cell(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public bool IsAlive { get; set; }

        public uint X { get; private set; }

        public uint Y { get; private set; }

        public override string ToString()
        {
            return string.Format("Cell : {0}, {1}, {2}", X, Y, IsAlive);
        }

        private bool Equals(Cell other)
        {
            return Equals(X, other.X) && Equals(Y, other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((Cell)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = (int)X;
            hashCode = (hashCode * 397) ^ Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Cell left, Cell right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !Equals(left, right);
        }
    }
}
