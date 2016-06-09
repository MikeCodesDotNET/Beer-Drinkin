using System;
using System.Collections;
using System.Collections.Generic;

namespace BeerDrinkin.iOS.Helpers
{
	public static class SearchHistory
	{
		public static Queue<string> History = new Queue<string>(3);

		public static void Add(string searchTerm)
		{
			History.Enqueue(searchTerm);

			if(History.Count > 3)
			{
				History.Dequeue();
			}
		} 	
	}
}

