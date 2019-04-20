using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class CommentsService
    {
        public bool AddComment(Comment comment)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Comments.Add(comment);

            return context.SaveChanges() > 0;
        }
        
        public List<Comment> GetComments(int entityID, int recordID, int recordsSize = 20)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Comments.Where(x => x.EntityID == entityID && x.RecordID == recordID).OrderByDescending(x=>x.TimeStamp).Take(recordsSize).ToList();
        }
        
        public List<Comment> GetComments(string userID, string searchTerm, int entityID, int? pageNo, int recordsSize)
        {
            DealDoubleContext context = new DealDoubleContext();

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * recordsSize;

            var comments = context.Comments.Where(x => x.EntityID == entityID)
                                   .AsQueryable();

            if (!string.IsNullOrEmpty(userID))
            {
                comments = comments.Where(x => x.UserID == userID);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                comments = comments.Where(x => x.Text.ToLower().Contains(searchTerm.ToLower()));
            }

            return comments.OrderByDescending(x => x.TimeStamp)
                           .Skip(skipCount)
                           .Take(recordsSize)
                           .ToList();
        }

        public int GetCommentsTotalCount(string userID, string searchTerm, int entityID)
        {
            DealDoubleContext context = new DealDoubleContext();

            var comments = context.Comments.Where(x => x.EntityID == entityID)
                                   .AsQueryable();

            if (!string.IsNullOrEmpty(userID))
            {
                comments = comments.Where(x => x.UserID == userID);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                comments = comments.Where(x => x.Text.ToLower().Contains(searchTerm.ToLower()));
            }

            return comments.Count();
        }

        public Comment GetComment(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Comments.Find(ID);
        }

        public bool DeleteComment(Comment comment)
        {
            if (comment != null)
            {
                DealDoubleContext context = new DealDoubleContext();

                context.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
