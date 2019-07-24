namespace ToyGraf.Models
{
    public class Trace
    {
        public string Formula
        {
            get => _Formula;
            set
            {
                if (Formula == value)
                    return;
                _Formula = value;
            }
        }

        private string _Formula;
    }
}
