using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Player
    {
		private string name;

		private string position;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty.");
                name = value;
            }
        }

        public string Position
		{
			get { return position; }
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
			        throw new ArgumentNullException("Invalid value");
				}
				else
				{
					position = value;
				}
			}
		}

        public Player(string name, string position)
        {
            Name = name;
            Position = position;
        }


    }
}
