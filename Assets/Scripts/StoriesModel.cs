using System;
using System.IO;
using System.Collections.Generic;

public class StoriesModel
{
    private List<StoryModel> stories = new List<StoryModel>();

    public StoriesModel(string textToImport)
    {
        using (var reader = new StringReader(textToImport))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                String[] fields = line.Split('\t');
                stories.Add(new StoryModel(fields[0], fields[1], Int32.Parse(fields[2])));
            }
        }
    }

    public StoryModel Story
    {
        get
        {
            int randomNumber = new System.Random().Next(stories.Count);
            for (int i = 0; i < stories.Count; i++)
            {
                if (i == randomNumber)
                {
                    return stories[i];
                }
            }
            throw new InvalidOperationException("No random story found");
        }
    }

    public List<StoryModel> Stories
    {
        get { return stories; }
    }

    public void RemoveStory(StoryModel story)
    {
        stories.Remove(story);
    }

    public class StoryModel
    {
        private Guid id;
        private string title;
        private string description;
        private int points;

        public StoryModel(string title, string description, int points)
        {
            this.id = Guid.NewGuid();
            this.title = title;
            this.description = description;
            this.points = points;
        }

        public Guid Id
        {
            get { return id; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string TitleSummary
        {
            get { return title.Length >= 35 ? title.Substring(0, 35) + "..." : title; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
