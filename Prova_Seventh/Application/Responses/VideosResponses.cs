using System;

using Prova.Domain.Entities;

namespace Prova.Application.Responses
{
    public class VideoResponse
    {
        public List<VideoResponseItem> Data { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int LastPage
        {
            get
            {
                return Data.Count / PerPage + 1;
            }
        }
    }

    public class VideoResponseItem
    {
        public string idVideo { get; set; }
        public string idServer { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class VideoResponseDetail
    {
        public VideoResponseDetail(string idvideo, string idserver, string description, string content, DateTime creationdate)
        {
            idVideo = idvideo;
            idServer = idserver;
            Description = description;
            Content = content;
            CreationDate = creationdate;
        }

        public string idVideo { get; protected set; }
        public string idServer { get; protected set; }
        public string Description { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        public static implicit operator VideoResponseDetail(Video dto)
            => new VideoResponseDetail(dto.idVideo, dto.idServer, dto.Description, dto.Content, dto.CreationDate);
    }

    public class VideoResponseBinary
    {       
        public VideoResponseBinary(string content)
        {
            Content = content + "";
        }

        public string Content { get; protected set; }
    }
}
