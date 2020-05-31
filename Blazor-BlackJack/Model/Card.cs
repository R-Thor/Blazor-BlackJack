namespace BlazorBlackJack.Model
{
    public class Card
    {
        public Card(string imagePath, int value)
        {
            ImagePath = imagePath;
            this.Value = value;
        }

        private int _height = 200;
        private int _width = 130;

        public bool IsShowing
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;

        }

        public int Width
        {
            get
            {
                return _width;
            }

        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int Value
        {
            get;
            set;
        }
    }
}
