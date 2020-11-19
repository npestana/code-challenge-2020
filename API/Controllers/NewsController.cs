using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class NewsController
    {
        /// <summary>
        /// Get an RSS feed content.
        /// </summary>
        /// <param name="feed">RSS feed url.</param>
        /// <returns>JSON object with the feed.</returns>
        [HttpGet("api/news/getrssnews")]
        public ActionResult<FeedDto> GetRssNews(string feed)
        {
            if (string.IsNullOrEmpty(feed))
            {
                return new NotFoundResult();
            }

            try
            {
                var feedObject = LoadFeed(feed);
                return ProcessFeed(feedObject);
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// Load the RSS feed.
        /// </summary>
        /// <param name="feedUrl">RSS feed url.</param>
        /// <returns></returns>
        private SyndicationFeed LoadFeed(string feedUrl)
        {
            var xmlReader = XmlReader.Create(feedUrl);
            
            return SyndicationFeed.Load(xmlReader);
        }

        /// <summary>
        /// Process the RSS feed.
        /// </summary>
        /// <param name="feedObject">Syndication Feed object.</param>
        /// <returns>Returns the feed dto.</returns>
        private FeedDto ProcessFeed(SyndicationFeed feedObject)
        {
            var feed = new FeedDto
            {
                Title = feedObject.Title.Text,
                Description = feedObject.Description.Text,
                Image = feedObject.ImageUrl.ToString()
            };
            
            if (feedObject.Items != null)
            {
                feed.Entries = ProcessFeedEntries(feedObject.Items);
            }

            return feed;
        }

        /// <summary>
        /// Process the feed entries.
        /// </summary>
        /// <param name="feedItems">List of SyndicationItem.</param>
        /// <returns>List of the feed entries dto.</returns>
        private List<FeedEntryDto> ProcessFeedEntries(IEnumerable<SyndicationItem> feedItems)
        {
            var entries = new List<FeedEntryDto>();

            foreach (var item in feedItems)
            {
                entries.Add(ProcessFeedEntry(item));
            }

            return entries;
        }

        /// <summary>
        /// Process a single feed entry.
        /// </summary>
        /// <param name="item">An SyndicationItem.</param>
        /// <returns>Return the feed entry dto.</returns>
        private FeedEntryDto ProcessFeedEntry(SyndicationItem item)
        {
            var feedEntry = new FeedEntryDto
            {
                Title = item.Title.Text,
                Link = item.Links?.First()?.Uri?.ToString(),
                PublishDate = item.PublishDate.ToString()
            };

            if (item.Authors == null)
            {
                return feedEntry;
            }
            
            feedEntry.Authors = new List<string>();

            foreach (var author in item.Authors)
            {
                feedEntry.Authors.Add(author.Name);
            }

            return feedEntry;
        }
    }
}
