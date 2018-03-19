using System;

namespace Jocker
{
	public class Player
	{
		public Player()
		{
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			var other = obj as Player;
			return other != null && other.Id == Id;
		}

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
	}
}