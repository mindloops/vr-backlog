using System.Collections;
using System;
using System.Collections.Generic;

public class StoriesModel
{
	private List<StoryModel> stories = new List<StoryModel> ();

	public StoriesModel ()
	{
		stories.Add (new StoryModel ("Full rewrite!!", "Throw everything out :)", 500));
		stories.Add (new StoryModel ("As a customer I want to change my password", "Lorum ipsum bla", 5));
		stories.Add (new StoryModel ("As a customer I want to add items to my shopping card", "Lorum ipsum bladiebla", 2));
		stories.Add (new StoryModel ("As a customer I want to pay with iDeal", "Lorum ipsum dolor", 3));
		stories.Add (new StoryModel ("As a merchant I want to sell my product", "Lorum ipsum haha", 10));
	}

	public StoryModel Story
	{
		get{
			int randomNumber = new System.Random ().Next (stories.Count);
			for (int i = 0; i < stories.Count; i++) {
				if (i == randomNumber) {
					return stories [i];
				}
			}
			throw new InvalidOperationException ("No random story found"); 
		}
	}

	public List<StoryModel> Stories
	{
		get { return stories; } 
	}

	public class StoryModel
	{
		private Guid id;
		private string title;
		private string description;
		private int points;

		public StoryModel(string title, string description, int points) {
			this.id = Guid.NewGuid();
			this.title = title;
			this.description = description;
			this.points = points;
		}

		public Guid Id {
			get { return id; }
		}

		public string Title {
			get { return title; }
			set { title = value; }
		}

		public string TitleSummary {
			get { return title.Length >= 35 ? title.Substring (0, 35) + "..." : title;  }
		}

		public string Description {
			get { return description; }
			set { description = value; }
		}

		public int Points {
			get { return points; }
			set { points = value; }
		}
	}
}
